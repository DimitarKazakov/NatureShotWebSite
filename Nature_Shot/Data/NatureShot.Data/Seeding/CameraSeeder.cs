﻿namespace NatureShot.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using NatureShot.Data.Models;

    public class CameraSeeder : ISeeder
    {
        public CameraSeeder()
        {
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cameras.Any())
            {
                return;
            }

            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon powerShot S45" });

            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S110" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S230" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S330" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S400" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S410" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD10" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD20" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD30" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD40" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD110" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD400" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD430" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD450" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD550" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD600" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD630" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD640" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD700 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD750" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD770 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD780 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD790 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD800 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD850 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD870 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD880 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD890 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD900" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD940 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD950 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD960 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD970 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD980 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD990 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD1000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD1100 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD1200 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD1300 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD1400 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD3500 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD4000 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SD4500 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot 110 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot 320 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot 340 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot 520 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A5" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A5 Zoom" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A50" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A10" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A20" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A30" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A40" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A60" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A70" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A75" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A80" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A85" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A95" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A310" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A400" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A410" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A420" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A430" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A450" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A460" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A470" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A480" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A490" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A510" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A520" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A530" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A540" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A550" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A560" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A570 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A580" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A590 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A610" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A620" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A630" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A640" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A650 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A700" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A710 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A720 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A800" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A810" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A1000 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A1100 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A1200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A1300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A1400" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A2000 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A2200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A2300 HD" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A2500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A2600" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A3000 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A3100 I" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A3150 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A3200 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot A3300 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon Powershot A3400 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon Powershot A3500 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon Powershot A4000 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot D10" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot D20" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot D30" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot E1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G2" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G3" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G5" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G6" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G7" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G7 X" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G9" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G10" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G11" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G12" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G1 X" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G15" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot G16" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S1 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S2 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S3 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S5 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S10" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S20" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S30" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S40" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S45" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S50" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S60" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S70" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S80" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S90" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S95" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S110" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot S120" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX1 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX10 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX20 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX30 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX40 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX50 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX60 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX70 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX100 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX110 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX120 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX130 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX150 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX160 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX200 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX210 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX220 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX230 HS(features GPS)" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX240 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX260 HS(features GPS)" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX270 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX280 HS(features GPS)" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX400 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX410 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX420 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX430 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX500 IS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX510 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX520 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX530 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX540 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX600 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX610 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX620 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX700 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX710 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX720 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Canon PowerShot SX730 HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P6000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P7000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P7100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P7700" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix A" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix A900" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P7800" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P310" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P330" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P340" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix L810" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix L820" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix L830" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix L840" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P510" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P520" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P530" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P600" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P610" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix B500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P900" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Coolpix P1000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 J1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 V1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 J2" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 V2" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 J3" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 S1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 AW1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 V3" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 J4" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon 1 J5" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Z 7" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Z 6" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Z 50" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Z 5" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D1X" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D1H" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D2H" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D2X" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D2HS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D2XS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D3" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D3X" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D3S" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D4" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D4S" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D5" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D6" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D800" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D800E" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D600" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D610" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon Df" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D810" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D750" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D810A" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D850" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D780" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D70S" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D80" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D90" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D7000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D7100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D7200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D7500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D5000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D5100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D5200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D5300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D5500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D5600" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D50" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D40" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D40X" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D60" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D3100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D3200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D3300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D3400" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Nikon D3500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX100 II" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX100 III" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX100 IV" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX100 V" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX100 VI" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX100 VII" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX10" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX10 II" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX10 III" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX10 IV" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - RX1R II" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S30" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S40" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S45" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S50" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S60" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S70" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S75" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S80" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S85" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S90" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S500" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S600" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S650" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S700" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S730" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S750" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S780" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S800" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S930" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S950" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S980" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S2100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S3000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - S2000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W310" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W320" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W330" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W350" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W360" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W370" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W380" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W390" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W510" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W520" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W530" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W550" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W560" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W570" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W580" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W610" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W620" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W630" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W650" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W670" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W690" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W710" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W730" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W800" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W810" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Sony DSC - W830" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-20" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-25" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-26" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-35" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-40" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-46" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-47" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-100" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-110" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-115" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-120" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-130" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-140" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-150" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-170" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-180" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-190" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-200" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-210" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-230" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-240" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-250" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-270" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-280" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-290" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-300" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-310" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-320" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-330" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-340" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-350" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-360" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-3000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-3010" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-4000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-4010" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-4020" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-4030" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-4040" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-4050" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-5000" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-5010" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus FE-5030" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SH-1" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SH-2" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SH-3" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SH-21" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SH-50" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-310" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-320" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-350" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-500UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-510UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-550UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-560UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-565UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP - 570UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-590UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-600UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-610UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP - 620UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-700" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-800UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-810UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP - 820UZ" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SP-100EE" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SZ - 10" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SZ - 11" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SZ-12" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SZ-15" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SZ-16" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SZ-30" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "Olympus SZ-31" });

            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 5" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 5c" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 5s" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 6" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 6s" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone SE" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 7" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 7s" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 8" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone X" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone XR" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone XS" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 11" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 11Pro" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 12" });
            await dbContext.Cameras.AddAsync(new Camera { Model = "IPhone 12Pro" });
            dbContext.SaveChanges();
        }
    }
}
