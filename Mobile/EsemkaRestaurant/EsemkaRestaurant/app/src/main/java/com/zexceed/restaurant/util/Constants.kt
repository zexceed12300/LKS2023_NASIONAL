package com.zexceed.restaurant.util

import android.content.ContentValues
import android.content.Context
import android.content.res.Resources
import android.graphics.Bitmap
import android.graphics.Canvas
import android.graphics.pdf.PdfDocument
import android.net.Uri
import android.os.Build
import android.os.Environment
import android.provider.MediaStore
import android.view.LayoutInflater
import android.view.View
import android.widget.Toast
import androidx.annotation.RequiresApi
import com.zexceed.restaurant.databinding.PdfOrdersInvoiceBinding
import com.zexceed.restaurant.models.OrdersItemResponse
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import java.io.ByteArrayOutputStream

object Constants {

    const val TAG = "Response::::::"

    const val API_BASE_URL = "http://192.168.198.167:5000/Api/"

    @RequiresApi(Build.VERSION_CODES.Q)
    fun exportDataToExternalFile(context: Context, filename: String, data: ByteArray, mimeType: String) {
        val contentValues = ContentValues().apply {
            put(MediaStore.MediaColumns.DISPLAY_NAME, filename)
            put(MediaStore.MediaColumns.MIME_TYPE, mimeType)
            put(MediaStore.MediaColumns.RELATIVE_PATH, Environment.DIRECTORY_DOWNLOADS)
        }
        val resolver = context.contentResolver
        val uri: Uri? = resolver.insert(MediaStore.Downloads.EXTERNAL_CONTENT_URI, contentValues)
        if (uri != null) {
            val outputStream = resolver.openOutputStream(uri)
            outputStream?.write(data)
        }
    }

    @RequiresApi(Build.VERSION_CODES.Q)
    suspend fun exportDataToPdf(context: Context, data: OrdersItemResponse) {
        withContext(Dispatchers.Default) {
            try {
                val layoutBinding = PdfOrdersInvoiceBinding.inflate(LayoutInflater.from(context))
                val view = layoutBinding.root
                layoutBinding.apply {
                    tvOrderId.text = data.orderId
                    tvStatus.text = data.status
                    tvOrderDate.text = data.createdAt
                    var menuName = ""
                    var menuPrice = ""
                    for (item in data.orderDetails) {
                        menuName += "${item.quantity} ${item.menu.name}\n"
                        menuPrice += "Rp. " + item.menu.price + "\n"
                    }
                    tvMenuName.text = menuName
                    tvMenuPrice.text = menuPrice
                }
                val displayMetrics = Resources.getSystem().displayMetrics
                view.measure(
                    View.MeasureSpec.makeMeasureSpec(displayMetrics.widthPixels, View.MeasureSpec.EXACTLY),
                    View.MeasureSpec.makeMeasureSpec(displayMetrics.heightPixels, View.MeasureSpec.EXACTLY)
                )
                view.layout(0, 0, displayMetrics.widthPixels, displayMetrics.heightPixels)
                val bitmap = Bitmap.createBitmap(
                    view.measuredWidth,
                    view.measuredHeight,
                    Bitmap.Config.ARGB_8888
                )
                val canvas = Canvas(bitmap)
                view.draw(canvas)
                val scaledBitmap = Bitmap.createScaledBitmap(bitmap, view.measuredWidth, view.measuredHeight, true)

                val document = PdfDocument()
                val pageInfo1 = PdfDocument.PageInfo.Builder(view.measuredWidth, view.measuredHeight, 1).create()
                val page1 = document.startPage(pageInfo1)
                page1.canvas.drawBitmap(scaledBitmap, 0f, 0f, null)
                document.finishPage(page1)

                val outputStream = ByteArrayOutputStream()
                document.writeTo(outputStream)
                document.close()
                exportDataToExternalFile(context, "Order-${data.orderId}.pdf", outputStream.toByteArray(), "application/pdf")
                withContext(Dispatchers.Main) {
                    Toast.makeText(context, "Data Exported!", Toast.LENGTH_SHORT).show()
                }
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
    }
}