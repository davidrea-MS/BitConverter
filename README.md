# EndianBitConverter

Provides a big-endian and little-endian BitConverter that convert base data types to an array of bytes, and an array of bytes to base data types, regardless of machine architecture.

This fork cleans up and updates a few things. It was really intended for one or two specific projects rather than a direct replacement for the original.

## Changes in this fork

* Updated project and solution files. They're created and maintained with Visual Studio 2019.
* Updated to .NET Standard 2.0 and test project to .NET Framework 4.8. This removes a bunch of unused dependencies when used with .NET Standard 2.0 compatible frameworks but obviously means it **no longer works with older frameworks.**
* Changed the namespace from "BitConverter" to "EndianBitConverter" as the former clashes with the built-in BitConverter type. **This is a breaking change.**

## License

This project is licensed under the MIT License. See the included LICENSE.txt for details.