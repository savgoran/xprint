# XPrint architecture

This document describes the architecture visible in the archived source code. It intentionally distinguishes confirmed implementation details from modernization suggestions.

## 1. Graphic object model

`GraphicObjects.cs/GraphicObject.cs` defines the base abstraction:

- `[Serializable]`
- position and size as `PointF` / `SizeF`
- rotation
- DPI/source-unit metadata
- `HitTest` and rectangle hit testing through `GraphicsPath`
- geometric transforms using `Matrix.RotateAt`
- abstract editor rendering: `Draw(Graphics g)`
- abstract print rendering: `Print(Graphics g, int id)`

That separation is central to XPrint: an object can render itself in the editor and resolve/print itself for a specific variable-data record or page.

Concrete objects in the archive include:

- `TextObject`
- `ImageObject`
- `GraphicRectangle`
- `TicketObject`
- `LotoTicket`, `LotoTicket2`, `LotoTicket4`
- `TombolaObject`
- `MexPotvrda`, `MercatorMexPotvrda`

`GraphicObjectsCollection` acts as the document/container model.

## 2. DrawSurface editor

`DrawSurface.cs/DrawSurface.cs` is a WinForms `UserControl` that provides the visual editor.

Confirmed behavior includes:

- custom painting in `OnPaint`
- grid and margin drawing
- object rendering through `drawingObjects.DrawObjects(...)`
- selected-object rendering
- mouse down/move/up interaction
- object lookup using hit testing
- rectangular multi-selection
- move operations
- rotation operations
- keyboard movement and deletion
- zoom / de-zoom coordinate transforms

The original `comment.txt` contains an especially useful historical note dated **17 December 2004**, describing work on Corel-style selection handles and a “compound object” concept.

## 3. Template persistence

`DrawSurface` saves and restores `GraphicObjectsCollection` using `BinaryFormatter`.

That was a normal .NET-era implementation choice when the project was created, but it is unsafe for untrusted input today. A modern implementation should use an explicit versioned DTO format such as JSON, XML, MessagePack, or another safe serializer.

## 4. Physical coordinate system

Printing is based on physical units rather than screen pixels.

In `XPrint/Form1.cs`, the `PrintPage` handler sets:

```csharp
e.Graphics.PageUnit = GraphicsUnit.Millimeter;
```

and then delegates to:

```csharp
printObjects.PrintObjects(currentPage, e.Graphics);
```

`GraphicsUnitConverter` and related coordinate conversions support the distinction between editor/display units and the physical printed document.

## 5. Variable-data page resolution

`GraphicObjectsCollection.PrintObjects` iterates through the document's `GraphicObject` instances and calls `Print(...)` with an ID derived from the current page, object marker, and configured depth.

This is the key connection between a static layout and changing print records:

```text
static position/style
        +
record/page identifier
        |
        v
GraphicObject.Print(Graphics, id)
        |
        v
resolved printed output
```

Different domain objects use that ID to retrieve or calculate the content for the relevant printed item.

## 6. Print pipeline

The runtime print path is visible in `XPrint/Form1.cs`:

```text
Load template
   |
   v
GraphicObjectsCollection
   |
   v
PrintDocument.PrintPage
   |
   v
GraphicsUnit.Millimeter
   |
   v
GraphicObjectsCollection.PrintObjects
   |
   v
GraphicObject.Print
   |
   v
Windows printer driver / device
```

`XPrint` also contains print preview, print-range handling, and horizontal/vertical print offset controls.

## 7. Domain-specific configuration

Several domain objects contain historical absolute configuration paths, for example under:

```text
C:\Program Files\Common Files\LutrijaCG\Baze\...
```

Those paths are not secrets; they document the original deployment model. They are intentionally left in the source as archival evidence, but a modernized version should inject configuration rather than hard-code paths.

`GraphicObjects.cs/LotoTicket.xml` is retained as an example of coordinate/font configuration for a ticket layout.

## 8. What a modern XPrint 2.0 would change

A modern implementation could preserve the conceptual model while replacing infrastructure:

```text
GraphicObject       -> immutable/versioned document element model
DrawSurface         -> modern desktop/web canvas
BinaryFormatter     -> safe versioned JSON/MessagePack model
System.Drawing      -> SkiaSharp / PDF/vector renderer as appropriate
hard-coded paths    -> dependency-injected configuration
SQL in print object -> data-provider interfaces
PrintDocument       -> renderer + platform-specific print/export adapters
```

The strongest idea worth preserving is the separation between:

1. physical layout,
2. editor interaction,
3. domain-specific variable data, and
4. final rendering/printing.
