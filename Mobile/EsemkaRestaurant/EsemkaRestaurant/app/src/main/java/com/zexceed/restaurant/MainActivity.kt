package com.zexceed.restaurant

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.zexceed.restaurant.databinding.ActivityMainBinding
import com.zexceed.restaurant.preferences.AuthPreferences

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

    private lateinit var preferences: AuthPreferences

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        preferences = AuthPreferences(this@MainActivity)

        binding.apply {
            if (preferences.isAuthenticated()) {
                when(preferences.getRole()) {
                    AuthPreferences.AUTH_PREF_CUSTOMER -> {
                        val intent = Intent(this@MainActivity, CustomerActivity::class.java)
                        startActivity(intent)
                    }
                    AuthPreferences.AUTH_PREF_STAFF -> {
                        val intent = Intent(this@MainActivity, AdminActivity::class.java)
                        startActivity(intent)
                    }
                }
            }
            preferences.logout()
            intent = Intent(this@MainActivity, HomeActivity::class.java)
            startActivity(intent)
        }
    }
}