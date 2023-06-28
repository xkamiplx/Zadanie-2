string format = "A5";
Prostokąt arkusz = Prostokąt.ArkuszPapieru(format);
Console.WriteLine($"Arkusz papieru {format} ma wymiary");
Console.WriteLine($"Bok A: {Math.Round(arkusz.BokA)} mm");
Console.WriteLine($"Bok B: {Math.Round(arkusz.BokB)} mm");