package com.zexceed.restaurant

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Toast
import androidx.core.widget.doAfterTextChanged
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.ActivityLoginBinding
import com.zexceed.restaurant.models.AuthRequest
import com.zexceed.restaurant.preferences.AuthPreferences
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.net.HttpURLConnection

class LoginActivity : AppCompatActivity() {

    private lateinit var binding: ActivityLoginBinding

    private lateinit var preferences: AuthPreferences

    private fun validateInput(email: String, password: String): Boolean {
        binding.apply {
            if (email.isEmpty()) {
                ilEmail.isErrorEnabled = true
                ilEmail.error = "Email is empty!"
            }
            else if (password.isEmpty()) {
                ilPassword.isErrorEnabled = true
                ilPassword.error = "Password is empty!"
            }
            else {
                return true
            }
        }
        return false
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        preferences = AuthPreferences(this@LoginActivity)

        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.apply {
            etEmail.doAfterTextChanged { ilEmail.isErrorEnabled = false }
            etPassword.doAfterTextChanged { ilPassword.isErrorEnabled = false }

            btnLogin.setOnClickListener {
                val email = etEmail.text.toString().trim()
                val password = etPassword.text.toString().trim()

                if (validateInput(email, password)) {
                    val coroutineScope = CoroutineScope(Dispatchers.IO)
                    coroutineScope.launch {
                        val req = ApiServices(this@LoginActivity)
                        val res = req.loginAsStaff(AuthRequest(
                            email = email,
                            password = password,
                        ))
                        withContext(Dispatchers.Main) {
                            if (req.responseCode == HttpURLConnection.HTTP_OK) {
                                Toast.makeText(this@LoginActivity, "Login Berhasil", Toast.LENGTH_SHORT).show()
                                if (res != null) {
                                    preferences.AuthStaff(res.token)
                                    val intent = Intent(this@LoginActivity, AdminActivity::class.java)
                                    startActivity(intent)
                                }
                            } else {
                                tvMessage.text = "Username and password invalid!"
                                tvMessage.visibility = View.VISIBLE
                            }
                        }
                    }
                }
            }

            btnLoginCustomer.setOnClickListener {
                intent = Intent(this@LoginActivity, HomeActivity::class.java)
                startActivity(intent)
            }
        }
    }

    override fun onBackPressed() {
        //super.onBackPressed()
    }
}