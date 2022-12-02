using System.Drawing;
using System.Drawing.Imaging;

namespace MediaCatalog
{
    public class GifImage
    {
        private Image _gifImage;
        private FrameDimension _dimension;
        private int _frameCount;
        private int _currentFrame = -1;
        private bool _reverse;
        private int _step = 1;

        public GifImage(string path)
        {
            _gifImage = Image.FromFile(path);
            //initialize
            _dimension = new FrameDimension(_gifImage.FrameDimensionsList[0]);
            //gets the GUID
            //total frames in the animation
            _frameCount = _gifImage.GetFrameCount(_dimension);
        }

        public bool ReverseAtEnd
        {
            //whether the gif should play backwards when it reaches the end
            get { return _reverse; }
            set { _reverse = value; }
        }

        public Image GetNextFrame()
        {

            _currentFrame += _step;

            //if the animation reaches a boundary...
            if (_currentFrame >= _frameCount || _currentFrame < 0)
            {
                if (_reverse)
                {
                    _step *= -1;
                    //...reverse the count
                    //apply it
                    _currentFrame += _step;
                }
                else
                {
                    _currentFrame = 0;
                    //...or start over
                }
            }
            return GetFrame(_currentFrame);
        }

        public Image GetFrame(int index)
        {
            _gifImage.SelectActiveFrame(_dimension, index);
            //find the frame
            return (Image)_gifImage.Clone();
            //return a copy of it
        }
    }
}
