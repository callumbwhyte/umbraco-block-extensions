# Umbraco Block Extensions

<img src="docs/img/logo.png?raw=true" alt="Umbraco Block Extensions" width="250" align="right" />

[![NuGet release](https://img.shields.io/nuget/v/Our.Umbraco.Extensions.Blocks.svg)](https://www.nuget.org/packages/Our.Umbraco.Extensions.Blocks/)

## Getting started

This package is supported on Umbraco v10-v13

### Installation

Umbraco Block Extensions is available via [NuGet](https://www.nuget.org/packages/Our.Umbraco.Extensions.Blocks/).

To install with the .NET CLI, run the following command:

    $ dotnet add package Our.Umbraco.Extensions.Blocks

To install from within Visual Studio, use the NuGet Package Manager UI or run the following command:

    PM> Install-Package Our.Umbraco.Extensions.Blocks

## Usage

Umbraco Block Extensions includes extensions for cleanly working with Blocks (Block List, Block Grid) in Umbraco.

Use `GetBlocks(x => ...)` and `GetBlocks<T>(x => ...)` methods to locate Blocks matching specific criteria or types - also works with the singular `GetBlock()` / `GetBlocks()` methods.

On an individual Block the `GetContent<T>()` and `GetSettings<T>()` methods allow retrieving the content or settings in a null / type safe way.

The `Html.RenderElement()` and `Html.RenderElements()` helpers make it easy to render HTML views for a mixed list of Blocks, passing the content model as the primary view model. Use the `ViewData.GetSettings<T>()` helper to access contextual settings in a null / type safe way.

### Picker Blocks

The custom "Picker" Block preview view located at `~/App_Plugins/Blocks/backoffice/pickerBlock.html` can be used to render a Multi Node Tree Picker property as if it were a Block. This allows to mix-and-match inline Blocks with external picked content within a single interface.

Create an [Element Type](https://docs.umbraco.com/umbraco-cms/fundamentals/data/defining-content/default-document-types) with a single Multi Node Tree Picker property. Assign it to a Block List or Block Grid editor and select the `pickerBlock` view.

Clicking a picker block will prevent the default Block editor UI from loading and will open picker in a dialog.

## Contribution guidelines

To raise a new bug, create an issue on the GitHub repository. To fix a bug or add new features, fork the repository and send a pull request with your changes. Feel free to add ideas to the repository's issues list if you would to discuss anything related to the library.

### Who do I talk to?

This project is maintained by [Callum Whyte](https://callumwhyte.com/) and contributors. If you have any questions about the project please raising an issue on GitHub.

## Credits

The package logo uses the [Block](https://thenounproject.com/icon/block-8187259/) icon from the [Noun Project](https://thenounproject.com/) by [Wahyu Adam](https://thenounproject.com/creator/flatsain141/), licensed under [CC BY 3.0 US](https://creativecommons.org/licenses/by/3.0/us/).

## License

Copyright &copy; 2026 [Callum Whyte](https://callumwhyte.com/), and other contributors

Licensed under the [MIT License](LICENSE.md).