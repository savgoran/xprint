# XPrint

**XPrint** is an archival C#/.NET variable-data printing system with a custom WYSIWYG layout editor, reusable graphic-object model, physical millimeter-based rendering, template persistence, and domain-specific print objects.

The codebase started in **2004** and continued to evolve over the following years; files in this archive span roughly **2004–2014**. It is published primarily as a historical software-engineering project rather than as a modern, production-ready printing package.

## What XPrint does

XPrint separates document design from print-time variable data:

```text
                 DESIGN TIME

  ShemaEdit -> DrawSurface -> GraphicObjects
                              |
                              v
                        saved template

                 PRINT TIME

  saved template -> GraphicObjectsCollection
                           |
                    variable data
                           |
                           v
                       XPrint
                           |
                    PrintDocument
                           |
                           v
                        printer
```

The core model is built around `GraphicObject`, an abstract serializable element that exposes separate rendering operations:

```csharp
public abstract void Draw(Graphics g);
public abstract void Print(Graphics g, int id);
```

This allows the same document model to support interactive editor rendering and variable-data print rendering.

## Highlights

- Custom **WinForms WYSIWYG editor** (`DrawSurface`)
- Object selection, multi-selection, drag, keyboard movement, hit testing, rotation, and selection rectangles
- Reusable graphic primitives and compound/domain objects
- Physical-coordinate printing using `GraphicsUnit.Millimeter`
- Screen/device unit conversion through `GraphicsUnitConverter`
- Template persistence using .NET serialization
- Print preview and Windows `PrintDocument` pipeline
- Variable print objects for ticket, lottery/tombola-style, combination, and certificate layouts
- Print depth / page sequencing logic in `GraphicObjectsCollection.PrintObjects`
- XML-based layout/configuration support for some ticket formats

## Main projects

| Project | Purpose |
| --- | --- |
| `GraphicObjects.cs` | Core document object model and printable/domain-specific objects |
| `DrawSurface.cs` | WYSIWYG editor surface and object manipulation |
| `ShemaEdit` | Layout/schema editor built on `DrawSurface` |
| `PotvrdaEdit` | Specialized certificate/layout editor |
| `XPrint` | Print-time application and print pipeline |
| `TicketEdit` | Earlier/legacy ticket editing and printing code |
| `Setup1`, `TopciderInstaller`, `TombolaPrint` | Historical Visual Studio installer project definitions |

The original Visual Studio solution is retained as `Topcider.sln`.

## Architecture

At a high level:

```text
+--------------------------------------------------+
|                    XPrint                         |
|      print ranges / preview / PrintDocument       |
+--------------------------------------------------+
|              Product-specific objects             |
| TicketObject / LotoTicket / TombolaObject / ...   |
+--------------------------------------------------+
|              GraphicObjects model                 |
| TextObject / ImageObject / Rectangle / ...        |
+--------------------------------------------------+
|                  DrawSurface                      |
| select / move / rotate / zoom / grid / serialize |
+--------------------------------------------------+
|             System.Drawing / GDI+                 |
|  Graphics / Matrix / GraphicsPath / millimeters   |
+--------------------------------------------------+
|              Windows print subsystem              |
+--------------------------------------------------+
```

See [docs/architecture.md](docs/architecture.md) for a source-grounded walkthrough.

## Historical implementation details

The project uses the Visual Studio 2008-era MSBuild format (`ToolsVersion="3.5"`) and classic .NET Framework technologies including:

- C# / WinForms
- `System.Drawing` / GDI+
- `System.Drawing.Printing.PrintDocument`
- `BinaryFormatter` template serialization
- ADO.NET / SQL Server and, historically, Microsoft Jet/Access for some data-driven workflows

Some code contains old machine-local file paths and assumptions that reflect the original deployment environment. They are retained where they are part of the historical implementation and should not be treated as current configuration guidance.

## Repository cleanup for publication

This public-ready snapshot intentionally excludes generated or potentially sensitive material from the original archive, including:

- `bin/`, `obj/`, Debug/Release outputs
- `.exe`, `.dll`, `.pdb`, `.msi` build artifacts
- Visual Studio user state and Visual SourceSafe metadata
- upgrade logs and backup copies
- the historical `Penzioneri012008.mdb` data file
- machine-specific SQL Server host names in the two checked-in `App.config` files

Old assembly `HintPath` references to build-output DLLs were changed to `ProjectReference` entries so the source tree no longer depends on removed `bin` folders.

See [docs/publication-review.md](docs/publication-review.md) for details.

## Building

This repository is an **archival codebase**, not a currently supported build.

The projects use the Visual Studio 2008 / .NET 3.5-era project format. The most faithful environment is an older Windows/.NET Framework toolchain. A recent Visual Studio version may offer to upgrade the projects.

Data-dependent features will not run as-is because historical databases and deployment-specific data files are intentionally not included.

The `.vdproj` setup projects may also require Visual Studio Installer project support and are not required to inspect the core source.

## Security and modernization note

The source predates current .NET security guidance. In particular, `BinaryFormatter` is used for template persistence and must **not** be used with untrusted input in a modern application. A modern rewrite should replace it with a safe, versioned serialization format.

## Author and license

XPrint is published by its original author, **Goran Savkić**, as an archival software-engineering project.

No open-source license is granted by this repository. Unless and until an explicit license is added, the source is **all rights reserved** and viewing the public source does not by itself grant rights to copy, modify, redistribute, or use it in another product.
