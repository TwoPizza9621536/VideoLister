# Coding Style

This is an example of the coding style.

```csharp
using System;

namespace Namespace
{
    class Class
    {
        // Private and public variables
        private var _privateVar;
        public var PublicVar { get; set; }

        public Class()
        {
            _privateVar = PublicVar;
        }

        private Method(string args)
        {
            if (_privateVar)
            {
                Console.WriteLine(args);
            }
            else
            {
                Console.WriteLine("Error: No public variable set.")
            }
        }
    }
}
```

---

SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors

SPDX-License-Identifier: CC0-1.0

---
