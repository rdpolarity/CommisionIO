using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMISSION.io_WPF_add
{
    public class Palette
    {
        public Palette(Swatch primarySwatch, Swatch accentSwatch, int primaryLightHueIndex, int primaryMidHueIndex, int primaryDarkHueIndex, int accentHueIndex)
        {
            PrimarySwatch = primarySwatch;
            AccentSwatch = accentSwatch;
            PrimaryLightHueIndex = primaryLightHueIndex;
            PrimaryMidHueIndex = primaryMidHueIndex;
            PrimaryDarkHueIndex = primaryDarkHueIndex;
            AccentHueIndex = accentHueIndex;
        }

        public Swatch PrimarySwatch { get; }

        public Swatch AccentSwatch { get; }

        public int PrimaryLightHueIndex { get; }

        public int PrimaryMidHueIndex { get; }

        public int PrimaryDarkHueIndex { get; }

        public int AccentHueIndex { get; }
    }
}
