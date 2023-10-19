package com.zexceed.restaurant

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.FragmentMenuDetailsBinding
import com.zexceed.restaurant.preferences.CartPreferences
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class MenuDetailsFragment : Fragment() {

    private var _binding: FragmentMenuDetailsBinding? = null
    private val binding get() = _binding!!

    private lateinit var preferences: CartPreferences

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        // Inflate the layout for this fragment
        _binding = FragmentMenuDetailsBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        preferences = CartPreferences(requireActivity())

        binding.apply {

            val coroutineScope = CoroutineScope(Dispatchers.IO)
            coroutineScope.launch {
                val reqMenuDetails = ApiServices(requireActivity())
                val resMenuDetails = reqMenuDetails.getMenuDetails(arguments?.getString(
                    MENU_DETAILS_ID).toString())
                val reqPhoto = ApiServices(requireActivity())
                if (resMenuDetails != null) {
                    reqPhoto.getMenuPhoto(resMenuDetails.menuId, imgThumbnail)
                    requireActivity().runOnUiThread {
                        tvName.text = resMenuDetails.name
                        tvPrice.text = "Rp. "+resMenuDetails.price.toString()
                        tvDescription.text = resMenuDetails.description

                        var qty = 0
                        btnIncrement.setOnClickListener {
                            qty += 1
                            tvQty.text = qty.toString()
                        }
                        btnDecrement.setOnClickListener {
                            if (qty > 0)
                                qty -= 1
                            tvQty.text = qty.toString()
                        }
                        btnAdd.setOnClickListener {
                            preferences.addCart(
                                menuId = resMenuDetails.menuId,
                                menuName = resMenuDetails.name,
                                price = resMenuDetails.price,
                                qty = qty,
                            )
                        }
                    }
                }
            }
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    companion object {
        const val MENU_DETAILS_ID = "menuId"
    }
}