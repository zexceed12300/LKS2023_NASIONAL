package com.zexceed.restaurant

import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import androidx.core.widget.doAfterTextChanged
import androidx.recyclerview.widget.LinearLayoutManager
import com.google.android.material.dialog.MaterialAlertDialogBuilder
import com.zexceed.restaurant.adapter.TableAdapter
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.ActivityAdminBinding
import com.zexceed.restaurant.databinding.DialogAddTableBinding
import com.zexceed.restaurant.util.Constants.TAG
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.net.HttpURLConnection

class AdminActivity : AppCompatActivity() {

    private lateinit var binding: ActivityAdminBinding
    private lateinit var dialogBinding: DialogAddTableBinding

    private lateinit var mAdapter: TableAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityAdminBinding.inflate(layoutInflater)
        setContentView(binding.root)

        queryTable()

        binding.apply {
            refreshTable.setOnRefreshListener {
                queryTable()
                refreshTable.isRefreshing = false
            }
        }
    }

    private fun queryTable() {
        binding.apply {
            val coroutineScope = CoroutineScope(Dispatchers.IO)
            coroutineScope.launch {
                val req = ApiServices(this@AdminActivity)
                val res = req.getListTableStaff()
                if (req.responseCode == HttpURLConnection.HTTP_UNAUTHORIZED) {
                    intent = Intent(this@AdminActivity, LoginActivity::class.java)
                    startActivity(intent)
                }
                withContext(Dispatchers.Main) {
                    Log.d(TAG, "onCreate: ${res}")
                    mAdapter = TableAdapter(res)
                    rvTable.apply {
                        adapter = mAdapter
                        layoutManager = LinearLayoutManager(this@AdminActivity)
                        setHasFixedSize(true)
                    }
                }
            }
            btnAddTable.setOnClickListener {
                showAddTableDialog()
            }
        }
    }

    private fun showAddTableDialog() {
        dialogBinding = DialogAddTableBinding.inflate(layoutInflater)
        val dialogBuilder = MaterialAlertDialogBuilder(this@AdminActivity)
        dialogBuilder.setView(dialogBinding.root)
        val customDialog = dialogBuilder.create()

        dialogBinding.apply {

            etTableNumber.doAfterTextChanged { ilTableNumber.isErrorEnabled = false }

            btnCancel.setOnClickListener {
                customDialog.dismiss()
            }

            btnOpenTable.setOnClickListener {
                val number = etTableNumber.text.toString().trim()
                if (validateData(number)) {
                    val coroutineScope = CoroutineScope(Dispatchers.IO)
                    coroutineScope.launch {
                        val req = ApiServices(this@AdminActivity)
                        val res = req.storeTable(number = number.toInt())
                        if (req.responseCode == HttpURLConnection.HTTP_BAD_REQUEST) {
                            ilTableNumber.isErrorEnabled = true
                            ilTableNumber.error = req.errorMessage
                        }
                        else if (req.responseCode == HttpURLConnection.HTTP_UNAUTHORIZED) {
                            intent = Intent(this@AdminActivity, LoginActivity::class.java)
                            startActivity(intent)
                        }
                    }
                }
                customDialog.dismiss()
                queryTable()
            }
        }

        customDialog.show()
    }

    private fun validateData(number: String): Boolean {
        dialogBinding.apply {
            if (number.isEmpty()) {
                ilTableNumber.isErrorEnabled = true
                ilTableNumber.error = "fill table number!"
                return false
            }
            return true
        }
    }

    override fun onBackPressed() {
        //super.onBackPressed()
    }
}