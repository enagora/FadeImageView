using System;

using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics;
using Android.Views.Animations;
using Android.Graphics.Drawables;

namespace FadeImageSample
{
    public class FadeImageView : ImageView
    {
        Animation fadeInAnimation;
        Animation fadeOutAnimation;

        public FadeImageView(Context ctx) : base(ctx)
        {
            Initialize();
        }

        public FadeImageView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public FadeImageView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        void Initialize()
        {
            fadeInAnimation = new AlphaAnimation(0, 1)
            {
                Duration = 500
            };
            fadeOutAnimation = new AlphaAnimation(1, 0)
            {
                Duration = 100
            };
        }


        void DoAnimation(bool really, Action changePic)
        {
            if (!really)
                changePic();
            else
            {
                _changePicAnimation = changePic;
                fadeOutAnimation.AnimationEnd += FadeOutAnimation_AnimationEnd; ;
                StartAnimation(fadeOutAnimation);
            }
        }
        private Action _changePicAnimation;
        private void FadeOutAnimation_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
            _changePicAnimation();
            StartAnimation(fadeInAnimation);
            fadeOutAnimation.AnimationEnd -= FadeOutAnimation_AnimationEnd;
        }

        public void SetImageBitmap(Bitmap bm, bool animate)
        {
            DoAnimation(animate, () => SetImageBitmap(bm));
        }

        public void SetImageDrawable(Drawable drawable, bool animate)
        {
            DoAnimation(animate, () => SetImageDrawable(drawable));
        }

        public void SetImageResource(int resId, bool animate)
        {
            DoAnimation(animate, () => SetImageResource(resId));
        }

        public void SetImageURI(Android.Net.Uri uri, bool animate)
        {
            DoAnimation(animate, () => SetImageURI(uri));
        }
    }
}