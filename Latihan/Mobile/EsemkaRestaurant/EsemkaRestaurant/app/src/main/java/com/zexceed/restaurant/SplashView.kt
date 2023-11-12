package com.zexceed.restaurant

import android.animation.Animator
import android.animation.AnimatorListenerAdapter
import android.animation.AnimatorSet
import android.animation.Keyframe
import android.animation.PropertyValuesHolder
import android.animation.ValueAnimator
import android.content.Context
import android.graphics.Canvas
import android.graphics.Color
import android.graphics.Paint
import android.graphics.RectF
import android.util.AttributeSet
import android.view.View
import android.view.animation.LinearInterpolator

class SplashView(context: Context, attrs: AttributeSet? = null) : View(context, attrs) {

    private val paint = Paint()

    var pileHeight: ArrayList<Float> = arrayListOf(
        0.6f, 1f, 0.6f, 1f, 0.6f
    )

    private val animatorSet = AnimatorSet()

    init {
        paint.apply {
            style = Paint.Style.FILL
            color = Color.GRAY
            isAntiAlias = true
            strokeCap = Paint.Cap.ROUND
        }

        val anim1Holder = PropertyValuesHolder.ofKeyframe("forward",
            Keyframe.ofFloat(0f, 0.6f),
            Keyframe.ofFloat(0.5f, 1f),
            Keyframe.ofFloat(1f, 0.6f)
        )
        val anim1 = ValueAnimator.ofPropertyValuesHolder(anim1Holder)
        anim1.apply {
            duration = 1000
            repeatCount = ValueAnimator.INFINITE
            addUpdateListener {
                pileHeight[0] = it.animatedValue as Float
                pileHeight[2] = it.animatedValue as Float
                pileHeight[4] = it.animatedValue as Float
                invalidate()
            }
        }

        val anim2Holder = PropertyValuesHolder.ofKeyframe("backward",
            Keyframe.ofFloat(0f, 1f),
            Keyframe.ofFloat(0.5f, 0.6f),
            Keyframe.ofFloat(1f, 1f)
        )
        val anim2 = ValueAnimator.ofPropertyValuesHolder(anim2Holder)
        anim2.apply {
            duration = 1000
            repeatCount = ValueAnimator.INFINITE
            addUpdateListener {
                pileHeight[1] = it.animatedValue as Float
                pileHeight[3] = it.animatedValue as Float
            }
        }

        animatorSet.playTogether(anim1, anim2)
        animatorSet.start()
    }

    fun pile(w: Float, h: Float, margin: Float = 2f) : RectF {
        val rectWidth = width * w
        val rectHeight = height * h
        val left = ((width - rectWidth) / 2) - margin * 4
        val top = (height - rectHeight) / 2
        val right = left + rectWidth
        val bottom = top + rectHeight

        return RectF(left, top, right, bottom)
    }

    override fun onDraw(canvas: Canvas) {
        super.onDraw(canvas)

        val pile1 = pile(0.08f, pileHeight[0], 100f)
        val pile2 = pile(0.08f, pileHeight[1], 50f)
        val pile3 = pile(0.08f, pileHeight[2], 0f)
        val pile4 = pile(0.08f, pileHeight[3], -50f)
        val pile5 = pile(0.08f, pileHeight[4], -100f)
        canvas.drawRoundRect(pile1, 20f, 20f, paint)
        canvas.drawRoundRect(pile2, 20f, 20f, paint)
        canvas.drawRoundRect(pile3, 20f, 20f, paint)
        canvas.drawRoundRect(pile4, 20f, 20f, paint)
        canvas.drawRoundRect(pile5, 20f, 20f, paint)
    }
}