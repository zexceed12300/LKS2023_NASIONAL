package com.zexceed.restaurant

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import com.zexceed.restaurant.MenuDetailsFragment.Companion.MENU_DETAILS_ID
import com.zexceed.restaurant.adapter.MenuAdapter
import com.zexceed.restaurant.adapter.MenuPagerAdapter.Companion.MENU_TAB_CATEGORY
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.FragmentMenuPagerBinding
import com.zexceed.restaurant.util.Constants.TAG
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class MenuPagerFragment : Fragment() {

    private var _binding: FragmentMenuPagerBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var mAdapter: MenuAdapter

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentMenuPagerBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        var category = ""

        Log.d(TAG, "onViewCreated: ${arguments?.getInt(MENU_TAB_CATEGORY, 0).toString()}")

        when(arguments?.getInt(MENU_TAB_CATEGORY, 0)) {
            0 -> {
                category = "Ayam"
            }
            1 -> {
                category = "Camilan"
            }
            2 -> {
                category = "DagingSapi"
            }
            3 -> {
                category = "HappyMeal"
            }
            4 -> {
                category = "Ikan"
            }
            5 -> {
                category = "MakananPenutup"
            }
            6 -> {
                category = "Minuman"
            }
            7 -> {
                category = "PaketFamily"
            }
            8 -> {
                category = "SarapanPagi"
            }
        }

        val coroutineScope = CoroutineScope(Dispatchers.IO)

        binding.apply {
            mAdapter = MenuAdapter(
                onClick = { data ->
                    val bundle = Bundle().apply {
                        putString(MENU_DETAILS_ID, data.id)
                    }
                    findNavController().navigate(R.id.action_navigation_menu_to_menuDetailsFragment, bundle)
                }
            )

            coroutineScope.launch {
                val req = ApiServices(requireActivity())
                val data = req.getMenu(category)
                mAdapter.submitList(data)
                requireActivity().runOnUiThread {
                    rvMenu.apply {
                        adapter = mAdapter
                        setHasFixedSize(true)
                    }
                }
            }
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}