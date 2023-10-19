package com.zexceed.restaurant.models

data class AuthResponse(
    val token: String,
    val expired: String,
)
