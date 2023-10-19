package com.zexceed.restaurant

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.core.widget.doAfterTextChanged
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.ActivityHomeBinding
import com.zexceed.restaurant.preferences.AuthPreferences
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.net.HttpURLConnection

class HomeActivity : AppCompatActivity() {

    private lateinit var binding: ActivityHomeBinding

    private lateinit var preferences: AuthPreferences

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        preferences = AuthPreferences(this@HomeActivity)

        binding = ActivityHomeBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.apply {

            etInputTableCode.doAfterTextChanged {
                ilInputTableCode.isErrorEnabled = false
            }

            btnSubmit.setOnClickListener {
                val code = etInputTableCode.text.toString().trim()

                val coroutineScope = CoroutineScope(Dispatchers.IO)
                if (validateData(code)) {
                    coroutineScope.launch {
                        val req = ApiServices(this@HomeActivity)
                        val res = req.getTable(code)
                        if (req.responseCode == HttpURLConnection.HTTP_OK) {
                            preferences.AuthCustomer(code)
                            intent = Intent(this@HomeActivity, CustomerActivity::class.java)
                            startActivity(intent)
                        }
                        else {
                            withContext(Dispatchers.Main) {
                                ilInputTableCode.isErrorEnabled = true
                                ilInputTableCode.error = res.toString()
                            }
                        }
                    }
                }
            }

            btnLoginStaff.setOnClickListener {
                intent = Intent(this@HomeActivity, LoginActivity::class.java)
                startActivity(intent)
            }
        }
    }

    private fun validateData(code: String) : Boolean {
        binding.apply {
            if (code.isEmpty()) {
                ilInputTableCode.isErrorEnabled = true
                ilInputTableCode.error = getString(R.string.validate_code)
            }
            else {
                return true
            }
        }
        return false
    }

    override fun onBackPressed() {
        //super.onBackPressed()
    }
}