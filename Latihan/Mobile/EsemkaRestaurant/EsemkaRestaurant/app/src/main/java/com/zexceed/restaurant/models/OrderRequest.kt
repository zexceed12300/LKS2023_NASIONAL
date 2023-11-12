package com.zexceed.restaurant.models

data class OrderRequest(
    val menuId: String,
    val quantity: Int,
)
