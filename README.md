# AxeFxPresetsToCubase
C# Console tool allowing to convert an AxeEdit Presets export to a MidiDeviceManager script in Cubase

HOW TO generate your custom Axe FX presets for Cubase:
1. Using AxeEdit, use the export function from the menus: Tools/Export As Text/Presets List...
2. run a  commmand prompt window go to the executable tool location  and type the command AFXPC2CUBASE "inputFilePath"
where "inputFilePah" is the full export file path generated by AxeEdit.
3. in the same location as the input file, you should now find a file named AxeFX3.txt that can be copied in the midi devices folder in Cubase.

Midi Devices in Cubase are located from the following locations:

Windows example location for cubase 12 64 bit:
  C:\Users\UserName\AppData\Roaming\Steinberg\Cubase 12_64\Scripts\Patchnames\inactive\fas

 Mac OSX example location for cubase 12 64 bit:
  /Users/UserName/Library/Preferences/Cubase 12/Scripts/Patchnames/inactive/fas

Note 1: Replace UserName is is your Windows or Mac OSX username.
Note 2: Similar locations exist for previous Cubase versions, just find the corresponding version cubase folder name.

Should work in principle with any FAS devices even though I did not test the other models
