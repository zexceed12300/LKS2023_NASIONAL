import android.content.Context
import android.graphics.Canvas
import android.graphics.Paint
import android.util.AttributeSet
import android.view.View
import android.animation.ValueAnimator
import android.view.animation.LinearInterpolator

class PlaceholderView(context: Context, attrs: AttributeSet? = null) : View(context, attrs) {

    private val paint = Paint()
    private var boxOpacity = 0f
    private val boxColor = 0xFFCCCCCC.toInt() // Warna kotak placeholder
    private val boxWidth = 200f // Lebar kotak
    private val boxHeight = 200f // Tinggi kotak
    private val animator = ValueAnimator.ofFloat(0f, 1f)

    init {
        paint.color = boxColor
        paint.style = Paint.Style.FILL

        animator.duration = 1000 // Durasi animasi (misalnya, 1 detik)
        animator.repeatCount = ValueAnimator.INFINITE
        animator.interpolator = LinearInterpolator()

        animator.addUpdateListener {
            boxOpacity = 0.3f + 0.7f * it.animatedValue as Float
            invalidate()
        }
    }

    override fun onDraw(canvas: Canvas) {
        super.onDraw(canvas)

        val centerX = width / 2f
        val centerY = height / 2f

        paint.alpha = (boxOpacity * 255).toInt()
        canvas.drawRect(centerX - boxWidth / 2, centerY - boxHeight / 2, centerX + boxWidth / 2, centerY + boxHeight / 2, paint)
    }

    fun startAnimation() {
        animator.start()
    }

    fun stopAnimation() {
        animator.cancel()
    }
}
