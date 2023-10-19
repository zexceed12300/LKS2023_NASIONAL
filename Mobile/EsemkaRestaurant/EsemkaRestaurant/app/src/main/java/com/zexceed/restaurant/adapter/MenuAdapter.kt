package com.zexceed.restaurant.adapter

import android.annotation.SuppressLint
import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.ItemMenuBinding
import com.zexceed.restaurant.models.MenuItemResponse
import com.zexceed.restaurant.util.Constants.API_BASE_URL
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class MenuAdapter(
    private val onClick: (MenuItemResponse) -> Unit
): ListAdapter<MenuItemResponse, MenuAdapter.ViewHolder>(DIFF_CALLBACK) {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val binding = ItemMenuBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ViewHolder(binding)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        holder.bind(getItem(position))
    }

    inner class ViewHolder(private val binding: ItemMenuBinding) : RecyclerView.ViewHolder(binding.root) {
        fun bind(data: MenuItemResponse) {

            val coroutineScope = CoroutineScope(Dispatchers.IO)

            binding.apply {
                tvTitle.text = data.name
                tvPrice.text = data.price.toString()
                coroutineScope.launch {
                    ApiServices(itemView.context).loadImage("${API_BASE_URL}Menu/${data.id}/Photo", imgThumbnail)
                }
                itemView.setOnClickListener {
                    onClick(data)
                }
            }
        }
    }

    companion object {
        val DIFF_CALLBACK: DiffUtil.ItemCallback<MenuItemResponse> = object: DiffUtil.ItemCallback<MenuItemResponse>() {
            override fun areItemsTheSame(oldItem: MenuItemResponse, newItem: MenuItemResponse): Boolean {
                return newItem.id == oldItem.id
            }

            @SuppressLint("DiffUtilEquals")
            override fun areContentsTheSame(oldItem: MenuItemResponse, newItem: MenuItemResponse): Boolean {
                return oldItem == newItem
            }

        }
    }
}