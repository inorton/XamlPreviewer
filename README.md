XamlPreviewer (c) 2011 Ian Norton <inorton-at-gmail>

About
------

XamlPreviewer is rather like XamlPad for mono/linux. Built on top of moonlight you can view and edit Xaml files. 

<img src="https://github.com/inorton/XamlPreviewer/raw/master/screenshots/xpv-0.2.1.png" alt="Screenshot"/>

Building
--------

You can either build using monodevelop / xbuild or by using mdtool. One useful way
is to use mdtool to generate makefiles like so:

$ mdtool generate-makefiles -d:Debug XamlPreviewer.sln

And then build like a normal autoconf/configure package

$ ./autogen.sh
$ make
$ sudo make install

You can then run "xamlpreviewer"
