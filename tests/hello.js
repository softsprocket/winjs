
console.log('Hello, World!');

var x = [1, 2, 3];

function y () {
    console.log ({ x: 1, y: 2 });
}

console.log('hello', x, y);

y ();

var s = "";
while (true) {
    var x = console.read ();
    s = s + x;
    if (x == '\n') {
        break;
    }
}
console.log (s);

var y = console.readline ();
console.log (y);

console.log (os.cwd ());
os.cd ('..\\');
console.log (os.cwd());

var strs = os.ls ();

for (var i in strs) {
    console.log (strs[i]);
}

strs = os.ls ("..\\", '*.cs');

for (var i in strs) {
    console.log (strs[i]);
}

