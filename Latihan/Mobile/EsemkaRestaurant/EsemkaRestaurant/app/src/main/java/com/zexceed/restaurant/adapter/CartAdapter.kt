package com.zexceed.restaurant.adapter

import android.annotation.SuppressLint
import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.ItemCartBinding
import com.zexceed.restaurant.models.Cart
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class CartAdapter(
    private val onClickQtyDecrement: (Cart) -> Unit,
    private val onClickQtyIncrement: (Cart) -> Unit,
    private val onClickRemove: (Cart) -> Unit
): ListAdapter<Cart, CartAdapter.ViewHolder>(DIFF_CALLBACK) {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val binding = ItemCartBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ViewHolder(binding)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        holder.bind(getItem(position))
    }

    inner class ViewHolder(private val binding: ItemCartBinding) : RecyclerView.ViewHolder(binding.root) {
        fun bind(data: Cart) {

            val coroutineScope = CoroutineScope(Dispatchers.IO)

            binding.apply {
                tvName.text = data.name
                tvPrice.text = "Rp. "+data.price.toString()
                tvQty.text = data.qty.toString()
                coroutineScope.launch {
                    val reqPhoto = ApiServices(itemView.context)
                    reqPhoto.getMenuPhoto(data.menuId, imgThumbnail)
                }

                btnDecrement.setOnClickListener {
                    onClickQtyDecrement(data)
                    tvQty.text = data.qty.toString()
                }

                btnIncrement.setOnClickListener {
                    onClickQtyIncrement(data)
                    tvQty.text = data.qty.toString()
                }

                btnRemove.setOnClickListener {
                    onClickRemove(data)
                }
            }
        }
    }

    companion object {
        val DIFF_CALLBACK: DiffUtil.ItemCallback<Cart> = object: DiffUtil.ItemCallback<Cart>() {
            override fun areItemsTheSame(oldItem: Cart, newItem: Cart): Boolean {
                return oldItem.menuId == newItem.menuId
            }

            @SuppressLint("DiffUtilEquals")
            override fun areContentsTheSame(oldItem: Cart, newItem: Cart): Boolean {
                return oldItem == newItem
            }

        }
    }
}