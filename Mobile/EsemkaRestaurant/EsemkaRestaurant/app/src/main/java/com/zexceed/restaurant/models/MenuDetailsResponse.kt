package com.zexceed.restaurant.models

data class MenuDetailsResponse(
    val menuId: String,
    val name: String,
    val description: String,
    val category: String,
    val price: Int,
)
