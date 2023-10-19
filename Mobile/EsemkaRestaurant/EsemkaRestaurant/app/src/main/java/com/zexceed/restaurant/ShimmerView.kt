package com.zexceed.restaurant

import android.animation.Animator
import android.animation.AnimatorListenerAdapter
import android.animation.AnimatorSet
import android.animation.ObjectAnimator
import android.animation.ValueAnimator
import android.content.Context
import android.graphics.Canvas
import android.graphics.Color
import android.graphics.Paint
import android.graphics.RectF
import android.util.AttributeSet
import android.view.View
import android.view.animation.AccelerateDecelerateInterpolator
import android.view.animation.AccelerateInterpolator
import android.view.animation.AnticipateInterpolator
import android.view.animation.AnticipateOvershootInterpolator
import android.view.animation.BounceInterpolator
import android.view.animation.DecelerateInterpolator
import android.view.animation.LinearInterpolator
import android.view.animation.OvershootInterpolator

class ShimmerView(context: Context, attrs: AttributeSet?) : View(context, attrs) {

    val animatorSet = AnimatorSet()

    private val paint = Paint()
    private val color = Color.GRAY
    private var cornerRadius = 0f
    var minOpacity = 125f
    var maxOpacity = 255f
    var opacity = 125f

    private fun animate(minOpacity: Float, maxOpacity: Float) : ValueAnimator {
        val animator = ValueAnimator.ofFloat(minOpacity, maxOpacity).apply {
            duration = 1000
            repeatCount = 0
            interpolator = LinearInterpolator()
            addUpdateListener {
                opacity = it.animatedValue as Float
                invalidate()
            }
        }

        return animator
    }

    init {
        val attributes = context.obtainStyledAttributes(attrs, R.styleable.ShimmerView)
        cornerRadius = attributes.getFloat(R.styleable.ShimmerView_shimmerCornerRadius, 0f)
        attributes.recycle()
        paint.color = color
        paint.style = Paint.Style.FILL

        val forwardAnimator = animate(minOpacity, maxOpacity)
        val backwardAnimator = animate(maxOpacity, minOpacity)

        animatorSet.playSequentially(forwardAnimator, backwardAnimator)

        val listener = object : AnimatorListenerAdapter() {
            override fun onAnimationEnd(animation: Animator) {
                animatorSet.start()
            }
        }

        animatorSet.addListener(listener)
        animatorSet.start()
    }

    override fun onDraw(canvas: Canvas) {
        super.onDraw(canvas)

        paint.alpha = opacity.toInt()
        val rect = RectF(0f, 0f, width.toFloat(), height.toFloat())
        canvas.drawRoundRect(rect, cornerRadius, cornerRadius, paint)
    }
}