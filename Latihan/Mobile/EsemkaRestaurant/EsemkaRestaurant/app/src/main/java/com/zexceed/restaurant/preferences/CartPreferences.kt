package com.zexceed.restaurant.preferences

import android.annotation.SuppressLint
import android.app.Activity
import android.content.Context
import android.content.SharedPreferences
import android.util.Log
import com.zexceed.restaurant.models.Cart
import com.zexceed.restaurant.util.Constants.TAG
import org.json.JSONArray
import org.json.JSONObject

class CartPreferences(private val context: Context) {
    private fun getSharedPreferences(): SharedPreferences {
        return context.getSharedPreferences(CART_PREF_NAME, Activity.MODE_PRIVATE)
    }

    @SuppressLint("MutatingSharedPrefs")
    fun addCart(
        menuId: String,
        menuName: String,
        price: Int,
        qty: Int,
    ) {
        val jsonString = getSharedPreferences().getString(CART_JSON, "[]")
        val jsonArray = JSONArray(jsonString)

        for (i in 0 until jsonArray.length()) {
            val jsonObject = jsonArray.getJSONObject(i)
            if (jsonObject.getString("menuId") == menuId) {
                return
            }
        }

        val jsonObject = JSONObject()
        jsonObject.put("menuId", menuId)
        jsonObject.put("menuName", menuName)
        jsonObject.put("price", price)
        jsonObject.put("qty", qty)
        jsonArray.put(jsonObject)

        getSharedPreferences().edit().apply {
            putString(CART_JSON, jsonArray.toString())
            apply()
        }
    }

    fun updateCart(
        menuId: String,
        menuName: String,
        price: Int,
        qty: Int,
    ) {
        val jsonString = getSharedPreferences().getString(CART_JSON, "[]")
        val jsonArray = JSONArray(jsonString)

        for (i in 0 until jsonArray.length()) {
            val jsonObject = jsonArray.getJSONObject(i)
            if (jsonObject.getString("menuId") == menuId) {
                jsonObject.put("menuId", menuId)
                jsonObject.put("menuName", menuName)
                jsonObject.put("price", price)
                jsonObject.put("qty", qty)
                jsonArray.put(i, jsonObject)
            }
        }

        getSharedPreferences().edit().apply {
            putString(CART_JSON, jsonArray.toString())
            apply()
        }
    }

    fun deleteCart(menuId: String) {
        val jsonString = getSharedPreferences().getString(CART_JSON, "[]")
        val jsonArray = JSONArray(jsonString)

        for (i in 0 until jsonArray.length()) {
            val jsonObject = jsonArray.getJSONObject(i)
            if (jsonObject.getString("menuId") == menuId) {
                Log.d(TAG, "deleteCart: ${menuId}")
                Log.d(TAG, "deleteCart: ${jsonArray.getJSONObject(i)}")
                jsonArray.remove(i)
                break
            }
        }

        getSharedPreferences().edit().apply {
            putString(CART_JSON, jsonArray.toString())
            apply()
        }
    }

    fun getCartList() : List<Cart> {

        var list = arrayListOf<Cart>()

        val jsonString = getSharedPreferences().getString(CART_JSON, "[]")
        Log.d(TAG, "getCartList: ${jsonString}")
        val jsonArray = JSONArray(jsonString)
        for (i in 0 until jsonArray.length()) {
            val jsonObject = jsonArray.getJSONObject(i)
            val menuId = jsonObject.getString("menuId")
            val menuName = jsonObject.getString("menuName")
            val price = jsonObject.getInt("price")
            val qty = jsonObject.getInt("qty")
            list?.add(
                Cart(
                    menuId = menuId,
                    name = menuName,
                    price = price,
                    qty = qty,
                )
            )
        }

        return list
    }

    fun isCartEmpty() : Boolean {
        return getSharedPreferences().getString(CART_JSON, null)!!.isEmpty()
    }

    fun getTotalPrice() : Int {
        var totalPrice = 0
        val jsonString = getSharedPreferences().getString(CART_JSON, "[]")
        val jsonArray = JSONArray(jsonString)

        for (i in 0 until jsonArray.length()) {
            val jsonObject = jsonArray.getJSONObject(i)
            totalPrice += jsonObject.getInt("price") * jsonObject.getInt("qty")
        }

        return totalPrice
    }

    companion object {
        const val CART_PREF_NAME = "cartPrefs"
        const val CART_JSON = "cartJson"
    }
}