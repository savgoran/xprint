# Publication review

This snapshot was prepared from the original XPrint/Topcider archive for possible GitHub publication.

## Removed from the public-ready snapshot

The cleanup removed categories that are not useful as source history or could contain private/generated data:

- build directories: `bin/`, `obj/`, `Debug/`, `Release/`
- compiled artifacts: `.exe`, `.dll`, `.pdb`, `.msi`
- Visual Studio user state: `.suo`, `.user`, `.gpState`
- Visual SourceSafe metadata: `.scc`, `.vspscc`, `.vssscc`
- Visual Studio upgrade logs/reports
- backup project folders (`Backup`, `Backup1`, etc.)
- `ShemaEdit/Penzioneri012008.mdb`

The Access database was excluded because its schema indicates person-related fields such as name, address and personal identifier fields. Publishing the data file would be inappropriate even if its exact contents were not inspected.

## Sanitized

The checked-in `XPrint/App.config` and `ShemaEdit/App.config` originally contained deployment-specific SQL Server machine/database names. They were changed to local example connection strings using:

- `XPrintTickets`
- `XPrintCertificates`
- `XPrintTombola`
- local `SQLEXPRESS`

No passwords or API keys were found in those configuration files; the original connections used Windows integrated security.

## Project-file cleanup

Several projects referenced `GraphicObjects.dll` / `DrawSurface.dll` through `bin/Debug` or `bin/Release` `HintPath` entries. Since build output is intentionally excluded from Git, those references were replaced with normal project references.

This changes project metadata, not runtime application logic.

## Intentionally retained

Some historical implementation details remain because they are part of the source and are not credentials:

- old absolute `Program Files` configuration/data paths
- historical product/database terminology in source code
- generated typed DataSet source/schema (without the underlying `.mdb` data)
- old installer project definitions (`.vdproj`)
- original solution/project names
- `comment.txt` development notes from 2004/2005

## Publication status

The author has confirmed that he has the right to publish the complete source. This cleaned snapshot is therefore suitable for a public archival GitHub repository.

No open-source `LICENSE` file is included. Publication of source code and an open-source license are separate decisions; without an explicit license, the repository remains **all rights reserved**.
