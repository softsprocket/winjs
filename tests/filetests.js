
require (winjs/file);

var args = os.arguments ();

var fi = new FileInfo (args[1]);
var sr = fi.OpenText ();

while ((s = sr.ReadLine()) != null) {
    console.log (s);
}

