using System.Globalization;
using System.Text.RegularExpressions;

namespace Matemaatika_Funktsioonid.Services
{
    public class AnalyysiTulemus
    {
        public string Maaramispiirkond { get; set; } = "X: (-∞, ∞)";
        public string Tuletis { get; set; } = "";
        public string KriitilisedPunktid { get; set; } = "";
        public string Ekstreemumid { get; set; } = "";
    }

    public static class FunktsiooniAnalyys
    {
        public static AnalyysiTulemus Analüüsi(string valem)
        {
            var tulemus = new AnalyysiTulemus();
            try
            {
                tulemus.Tuletis = "f'(x): arvutatud numbriliselt";

                var kriitilised = LeiaKriitilisedPunktid(valem);

                if (kriitilised.Count > 0)
                {
                    tulemus.KriitilisedPunktid = string.Join(", ",
                        kriitilised.Select((x, i) => $"x{i + 1} = {Math.Round(x, 2)}"));

                    var ekstreemumid = new List<string>();
                    foreach (var x in kriitilised)
                    {
                        double y = Hinda(valem, x);
                        double teine = TeineTuletis(valem, x);
                        if (teine < -0.001)
                            ekstreemumid.Add($"max = {Math.Round(y, 2)} (x={Math.Round(x, 2)})");
                        else if (teine > 0.001)
                            ekstreemumid.Add($"min = {Math.Round(y, 2)} (x={Math.Round(x, 2)})");
                    }
                    tulemus.Ekstreemumid = string.Join(", ", ekstreemumid);
                }
                else
                {
                    tulemus.KriitilisedPunktid = "puuduvad";
                    tulemus.Ekstreemumid = "puuduvad";
                }

                if (valem.Contains("/x") || valem.Contains("/ x"))
                    tulemus.Maaramispiirkond = "X: (-∞, 0) ∪ (0, ∞)";
                else
                    tulemus.Maaramispiirkond = "X: (-∞, ∞)";
            }
            catch
            {
                tulemus.Tuletis = "ei saa arvutada";
            }
            return tulemus;
        }

        public static double Hinda(string valem, double x)
        {
            string expr = valem.ToLower()
                .Replace(" ", "")
                .Replace("^", "**")
                .Replace("x", x.ToString(CultureInfo.InvariantCulture));

            expr = Regex.Replace(expr, @"(\d+\.?\d*)\*\*(\d+\.?\d*)",
                m => Math.Pow(double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture),
                              double.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture))
                         .ToString(CultureInfo.InvariantCulture));

            var dt = new System.Data.DataTable();
            return Convert.ToDouble(dt.Compute(expr, ""));
        }

        private static double ArvutaTuletisArv(string valem, double x, double h = 1e-5)
            => (Hinda(valem, x + h) - Hinda(valem, x - h)) / (2 * h);

        private static List<double> LeiaKriitilisedPunktid(string valem)
        {
            var punktid = new List<double>();
            double samm = 0.01;
            for (double x = -10; x <= 10; x += samm)
            {
                double d1 = ArvutaTuletisArv(valem, x);
                double d2 = ArvutaTuletisArv(valem, x + samm);
                if (d1 * d2 < 0)
                {
                    double juur = Bisectsioon(valem, x, x + samm);
                    if (!punktid.Any(p => Math.Abs(p - juur) < 0.05))
                        punktid.Add(juur);
                }
            }
            return punktid;
        }

        private static double Bisectsioon(string valem, double a, double b, int iter = 50)
        {
            for (int i = 0; i < iter; i++)
            {
                double c = (a + b) / 2;
                if (ArvutaTuletisArv(valem, a) * ArvutaTuletisArv(valem, c) < 0) b = c;
                else a = c;
            }
            return (a + b) / 2;
        }

        private static double TeineTuletis(string valem, double x, double h = 1e-3)
            => (Hinda(valem, x + h) - 2 * Hinda(valem, x) + Hinda(valem, x - h)) / (h * h);
    }
}