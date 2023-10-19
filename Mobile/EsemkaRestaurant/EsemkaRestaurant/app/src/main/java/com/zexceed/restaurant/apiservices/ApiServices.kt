package com.zexceed.restaurant.apiservices

import android.content.Context
import android.graphics.BitmapFactory
import android.util.Log
import android.widget.ImageView
import com.zexceed.restaurant.models.AuthRequest
import com.zexceed.restaurant.models.AuthResponse
import com.zexceed.restaurant.models.MenuDetailsResponse
import com.zexceed.restaurant.models.MenuItemResponse
import com.zexceed.restaurant.models.MenuResponse
import com.zexceed.restaurant.models.OrderRequest
import com.zexceed.restaurant.models.OrdersItemDetailsMenuResponse
import com.zexceed.restaurant.models.OrdersItemDetailsResponse
import com.zexceed.restaurant.models.OrdersItemResponse
import com.zexceed.restaurant.models.OrdersResponse
import com.zexceed.restaurant.models.TableResponse
import com.zexceed.restaurant.models.staff.TableBadRequestErrorsResponseStaff
import com.zexceed.restaurant.models.staff.TableBadRequestResponseStaff
import com.zexceed.restaurant.models.staff.TableDetailsResponseStaff
import com.zexceed.restaurant.models.staff.TableItemResponseStaff
import com.zexceed.restaurant.models.staff.TableResponseStaff
import com.zexceed.restaurant.preferences.AuthPreferences
import com.zexceed.restaurant.util.Constants.API_BASE_URL
import com.zexceed.restaurant.util.Constants.TAG
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import org.json.JSONArray
import org.json.JSONObject
import java.io.BufferedReader
import java.io.InputStream
import java.io.InputStreamReader
import java.io.OutputStreamWriter
import java.net.HttpURLConnection
import java.net.URL

class ApiServices(context: Context) {

    var preferences = AuthPreferences(context)

    var responseCode: Int? = null
    var errorMessage: String? = null

    suspend fun loadImage(url: String, view: ImageView) {
        return withContext(Dispatchers.IO) {
            try {
                val connection = URL(url).openConnection() as HttpURLConnection
                connection.doInput = true
                connection.connect()

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val bitmap = BitmapFactory.decodeStream(inputStream)
                    withContext(Dispatchers.Main) {
                        view.setImageBitmap(bitmap)
                    }
                } else {
                    val errorStream = connection.errorStream
                    errorMessage = BufferedReader(InputStreamReader(errorStream)).readText()
                }
                responseCode = connection.responseCode
            } catch (e: Exception) {
                e.printStackTrace()
                null
            }
        }
    }

    suspend fun getTable(code: String) : Any? {

        val endpoint = "Table/${code}"

        var response: Any? = null

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL + endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.requestMethod = "POST"
                connection.connect()

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val json = BufferedReader(InputStreamReader(inputStream)).readText()
                    val jsonObject = JSONObject(json)
                    response = TableResponse(
                        id = jsonObject.getString("id"),
                        number = jsonObject.getInt("number"),
                    )
                } else {
                    val errorStream = connection.errorStream
                    response = BufferedReader(InputStreamReader(errorStream)).readText()
                }
                responseCode = connection.responseCode
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }

        return response
    }

    suspend fun getMenu(category: String) : MenuResponse {

        val endpoint = "Menu/Category/${category}"

        val data = MenuResponse()

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL + endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.connect()

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val json = BufferedReader(InputStreamReader(inputStream)).readText()
                    val jsonArray = JSONArray(json)
                    Log.d("API::::::", "getMenu: $jsonArray")
                    for (i in 0 until jsonArray.length()) {
                        val jsonObject = jsonArray.getJSONObject(i)
                        val menu = MenuItemResponse(
                            id = jsonObject.getString("id"),
                            name = jsonObject.getString("name"),
                            price = jsonObject.getInt("price")
                        )
                        data.add(menu)
                    }
                }

                responseCode = connection.responseCode

            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
        return data
    }

    suspend fun getMenuPhoto(menuId: String, view: ImageView) {

        val endpoint = "Menu/${menuId}/Photo"

        loadImage(API_BASE_URL+endpoint, view)
    }

    suspend fun getMenuDetails(menuId: String) : MenuDetailsResponse? {

        val endpoint = "Menu/${menuId}"

        var response: MenuDetailsResponse? = null

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL+endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.connect()
                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val res = BufferedReader(InputStreamReader(inputStream)).readText()
                    val jsonObject = JSONObject(res)
                    response = MenuDetailsResponse(
                        menuId = jsonObject.getString("menuId"),
                        name = jsonObject.getString("name"),
                        description = jsonObject.getString("description"),
                        category = jsonObject.getString("category"),
                        price = jsonObject.getInt("price"),
                    )
                } else {
                    val errorStream = connection.errorStream
                    errorMessage = BufferedReader(InputStreamReader(errorStream)).readText()
                }
                responseCode = connection.responseCode
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
        return response
    }

    suspend fun storeOrder(req: List<OrderRequest>) {

        Log.d(TAG, "storeOrder: ${preferences.getToken()}")
        val endpoint = "Table/${preferences.getToken()}/Order"

        withContext(Dispatchers.IO) {
            val url = URL(API_BASE_URL+endpoint)
            val connection = url.openConnection() as HttpURLConnection
            connection.requestMethod = "POST"
            connection.doInput = true
            connection.doOutput = true
            connection.setRequestProperty("Content-Type", "application/json")

            val outputStream = connection.outputStream
            val writer = OutputStreamWriter(outputStream)

            val jsonArray = JSONArray()
            for (item in req) {
                val jsonObject = JSONObject()
                jsonObject.put("menuId", item.menuId)
                jsonObject.put("quantity", item.quantity)
                jsonArray.put(jsonObject)
            }

            writer.write(jsonArray.toString())
            writer.flush()
            writer.close()
            outputStream.close()

            connection.connect()

            responseCode = connection.responseCode
        }
    }

    suspend fun getOrders() : OrdersResponse? {

        val endpoint = "Table/${preferences.getToken()}/Orders"

        var response = OrdersResponse()

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL+endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.connect()
                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val res = BufferedReader(InputStreamReader(inputStream)).readText()
                    val jsonArrayOrders = JSONArray(res)
                    for (i in 0 until jsonArrayOrders.length()) {
                        val jsonObjectOrder = jsonArrayOrders.getJSONObject(i)
                        val orderDetails = arrayListOf<OrdersItemDetailsResponse>()
                        val jsonArrayDetails = JSONArray(jsonObjectOrder.getString("orderDetails"))
                        for (j in 0 until jsonArrayDetails.length()) {
                            val details = jsonArrayDetails.getJSONObject(j)
                            val menu = details.getJSONObject("menu")
                            orderDetails.add(
                                OrdersItemDetailsResponse(
                                    quantity = details.getInt("quantity"),
                                    subTotal = details.getInt("subTotal"),
                                    menu = OrdersItemDetailsMenuResponse(
                                        menuId = menu.getString("menuId"),
                                        category = menu.getString("category"),
                                        description = menu.getString("description"),
                                        name = menu.getString("name"),
                                        price = menu.getInt("price"),
                                    ),
                                )
                            )
                        }
                        
                        response.add(
                            OrdersItemResponse(
                                orderId = jsonObjectOrder.getString("orderId"),
                                createdAt = jsonObjectOrder.getString("createdAt"),
                                status = jsonObjectOrder.getString("status"),
                                orderDetails = orderDetails
                            )
                        )
                    }
                } else {
                    val errorStream = connection.errorStream
                    errorMessage = BufferedReader(InputStreamReader(errorStream)).readText()
                }
                responseCode = connection.responseCode
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
        return response
    }

    suspend fun loginAsStaff(req: AuthRequest) : AuthResponse? {

        val endpoint = "Auth"

        var response: AuthResponse? = null

        withContext(Dispatchers.IO) {
            val url = URL(API_BASE_URL+endpoint)
            val connection = url.openConnection() as HttpURLConnection
            connection.requestMethod = "POST"
            connection.doInput = true
            connection.doOutput = true
            connection.setRequestProperty("Content-Type", "application/json")

            val outputStream = connection.outputStream
            val writer = OutputStreamWriter(outputStream)

            val jsonObject = """
                {
                    "email": "${req.email}",
                    "password": "${req.password}"
                }
            """.trimIndent()
            writer.write(jsonObject)
            writer.flush()
            writer.close()
            outputStream.close()

            connection.connect()

            if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                val inputStream = connection.inputStream
                val res = BufferedReader(InputStreamReader(inputStream)).readText()
                val jsonObject = JSONObject(res)
                response = AuthResponse(
                    token = jsonObject.getString("token"),
                    expired = jsonObject.getString("expired"),
                )
            } else {
                val errorStream = connection.errorStream
                errorMessage = BufferedReader(InputStreamReader(errorStream)).readText()
            }
            responseCode = connection.responseCode
        }
        return response
    }

    suspend fun getListTableStaff() : TableResponseStaff {

        val endpoint = "Table"

        val data = TableResponseStaff()

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL + endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.requestMethod = "GET"
                Log.d(TAG, "getListTable: ${preferences.getToken()}")
                connection.setRequestProperty("Authorization", "Bearer ${preferences.getToken()}")
                connection.connect()

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val json = BufferedReader(InputStreamReader(inputStream)).readText()
                    val jsonArray = JSONArray(json)
                    for (i in 0 until jsonArray.length()) {
                        val jsonObject = jsonArray.getJSONObject(i)
                        val item = TableItemResponseStaff(
                            id = jsonObject.getString("id"),
                            number = jsonObject.getInt("number"),
                            code = jsonObject.getString("code"),
                            total = jsonObject.getInt("total"),
                        )
                        data.add(item)
                    }
                } else {
                    val errorStream = connection.errorStream
                    errorMessage = BufferedReader(InputStreamReader(errorStream)).readText()
                }

                responseCode = connection.responseCode

            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
        return data
    }

    suspend fun getTableDetailsStaff(tableId: String) : TableDetailsResponseStaff? {

        val endpoint = "Table/${tableId}"

        var response: TableDetailsResponseStaff? = null

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL+endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.setRequestProperty("Authorization", "Bearer ${preferences.getToken()}")
                connection.connect()

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val res = BufferedReader(InputStreamReader(inputStream)).readText()

                    val table = JSONObject(res)

                    var orders = OrdersResponse()
                    val jsonArrayOrders = table.getJSONArray("orders")
                    Log.d(TAG, "getTableDetailsStaff: ${jsonArrayOrders}")
                    for (i in 0 until jsonArrayOrders.length()) {
                        val jsonObjectOrder = jsonArrayOrders.getJSONObject(i)
                        val orderDetails = arrayListOf<OrdersItemDetailsResponse>()
                        val jsonArrayDetails = JSONArray(jsonObjectOrder.getString("orderDetails"))
                        for (j in 0 until jsonArrayDetails.length()) {
                            val details = jsonArrayDetails.getJSONObject(j)
                            val menu = details.getJSONObject("menu")
                            orderDetails.add(
                                OrdersItemDetailsResponse(
                                    quantity = details.getInt("quantity"),
                                    subTotal = details.getInt("subTotal"),
                                    menu = OrdersItemDetailsMenuResponse(
                                        menuId = menu.getString("menuId"),
                                        category = menu.getString("category"),
                                        description = menu.getString("description"),
                                        name = menu.getString("name"),
                                        price = menu.getInt("price"),
                                    ),
                                )
                            )
                        }
                        orders.add(
                            OrdersItemResponse(
                                orderId = jsonObjectOrder.getString("orderId"),
                                createdAt = jsonObjectOrder.getString("createdAt"),
                                status = jsonObjectOrder.getString("status"),
                                orderDetails = orderDetails
                            )
                        )
                    }
                    response = TableDetailsResponseStaff(
                        tableId = table.getString("tableId"),
                        number = table.getInt("number"),
                        code = table.getString("code"),
                        closedAt = table.getString("closedAt"),
                        orders = orders
                    )

                } else {
                    val errorStream = connection.errorStream
                    errorMessage = BufferedReader(InputStreamReader(errorStream)).readText()
                }
                responseCode = connection.responseCode
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
        return response
    }

    suspend fun storeTable(number: Int) : String? {
        val endpoint = "Table?number=${number}"

        var response: String? = null

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL+endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.requestMethod = "POST"
                connection.setRequestProperty("Authorization", "Bearer ${preferences.getToken()}")
                connection.connect()

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val res = BufferedReader(InputStreamReader(inputStream)).readText()
                    response = res
                } else {
                    val errorStream = connection.errorStream
                    val res = BufferedReader(InputStreamReader(errorStream)).readText()
                    val jsonObject = JSONObject(res)

                    val jsonObjectError = jsonObject.getJSONObject("errors")
                    val jsonArrayNumber = jsonObjectError.getJSONArray("number")
                    var number = arrayListOf<String>()
                    for (i in 0 until jsonArrayNumber.length()) {
                        number.add(jsonArrayNumber.getString(i))
                    }

                    val errors = TableBadRequestErrorsResponseStaff(
                        number = number
                    )

                    val tableBadRequest = TableBadRequestResponseStaff(
                        type = jsonObject.getString("type"),
                        title = jsonObject.getString("title"),
                        status = jsonObject.getString("status"),
                        traceId = jsonObject.getString("traceId"),
                        errors = errors,
                    )

                    errorMessage = tableBadRequest.errors.number.get(0)
                }
                Log.d(TAG, "storeTable: ${connection.responseCode}")
                responseCode = connection.responseCode
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }

        return response
    }

    suspend fun closeTable(tableId: String): Any? {
        val endpoint = "Table/${tableId}/Close"

        var response: Any? = null

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL+endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.requestMethod = "PUT"
                connection.setRequestProperty("Authorization", "Bearer ${preferences.getToken()}")
                connection.connect()

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val res = BufferedReader(InputStreamReader(inputStream)).readText()
                    response = res
                } else {
                    val errorStream = connection.errorStream
                    val res = BufferedReader(InputStreamReader(errorStream)).readText()
                    errorMessage = res
                }
                responseCode = connection.responseCode
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }

        return response
    }

    suspend fun changeOrderStatus(tableId: String, orderId: String, status: String) {
        val endpoint = "Table/${tableId}/Order/${orderId}?status=${status}"

        var response: Any? = null

        withContext(Dispatchers.IO) {
            try {
                val url = URL(API_BASE_URL+endpoint)
                val connection = url.openConnection() as HttpURLConnection
                connection.requestMethod = "PUT"
                connection.setRequestProperty("Authorization", "Bearer ${preferences.getToken()}")
                connection.connect()

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val inputStream = connection.inputStream
                    val res = BufferedReader(InputStreamReader(inputStream)).readText()
                    response = res
                } else {
                    val errorStream = connection.errorStream
                    val res = BufferedReader(InputStreamReader(errorStream)).readText()
                    errorMessage = res
                }
                responseCode = connection.responseCode
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
    }
}