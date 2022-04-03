# Contributing

---

SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors

SPDX-License-Identifier: CC0-1.0

---

Thank you for contributing to this project,because this is a hobby project most
of the time I cannot work on the code so thank you. Before you can push to the
repository you will need follow these guidelines.

It is required to follow these guidelines, so you can respect our time down the
line and thank yourself in the future that you do not have to keep coming to us
trying to fix something that can be resolved here.

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Getting Started](#getting-started)
  - [Creating a Fork](#creating-a-fork)
  - [Coding Style](#coding-style)
  - [Documentation](#documentation)
  - [Testing](#testing)
  - [Before Committing](#before-committing)
- [Developer Certificate of Origin](#developer-certificate-of-origin)

## Code of Conduct

To make everybody to participate in a diverse community where anybody can
contribute, this project adopts the Contributor Covenant
[Code Of Conduct](CODE_OF_CONDUCT.md). By participating and/or contributing, you
are expected to uphold this code Please report unacceptable behavior to
<twopizza9621536@gmail.com>.

## Getting Started

To submit a contribution quickly do these steps:

1. Create your own fork of the code.
2. Make the changes in your fork.
3. Make sure you are following the [coding style](#coding-style).
4. Make sure you are documenting your code.
5. Before committing you are required to sign off your commit as you ar
   agreeing to the Developer Certificate of Origin that you own this code, and
   you agree that we can use this code. You are also required to sign the commit
   to verify that the code you submitted is from you.

### Creating a Fork

First go the [repository page][1] and in the top right corner of the page,
click fork. Then you clone your fork just like any git repository. Next, create
a new branch by typing this command:

```bash
git checkout -b `your branch name`
```

Replace `your branch name` with the branch name you want to use, make sure it
reflects that changes you want to make. Now you can make your changes and start
contributing.

### Coding Style

The coding style for Python, the coding style is [PEP8](https://pep8.org) with
these rules:

- Strings must be double quoted.

You can use autopep8 formatter plus pylint to format the files for you.
Pre-commit will do this for you if you have it installed.

### Documentation

To document your code use docstring. You can use an auto generator to create the
boilerplate for you. The autoDocstring should be good enough.

### Testing

You are required to test the code you have written to create a test, go into the
VideoLister. Tests directory and write a test based on the code you have
written.

See documentation for the language you want to test for more information.

### Before Committing

First check you have formatted, documented and tested your code as mention
above. Next use these command to commit your changes:

```bash
git add .                                  # Stage your changes
git commit -S -s -m -a "Your changes here" # -S Sign your code
git push                                   # -s Sign off your code
```

This command will commit your changes, sign your commit and sign off your
commit. Signing the commit prevents malicious code making its way in to the
repository and check the commit is from you. You must have a PGP Key or X.509
certificate to sign your commit. To learn about signing commits, see this
[tutorial from GitHub][2] about signing commits. Signing off the commit grant us
the permission to use the code in your commit for this project, see below for
more information.

## Developer Certificate of Origin

Below is a copy of a [Developer Certificate of Origin][3] in which you agree
that the code you have submitted is yours or that you are allowed to use this
code and that we can use the code you have submitted for this project under the
[BSD 3-Clause License](LICENSE) using the following SPDX license identifier
expressions:

```text
SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors

SPDX-License-Identifier: BSD-3-Clause
```

Begin Developer Certificate of Origin

```text
Developer Certificate of Origin
Version 1.1

Copyright (C) 2004, 2006 The Linux Foundation and its contributors.

Everyone is permitted to copy and distribute verbatim copies of this
license document, but changing it is not allowed.


Developer's Certificate of Origin 1.1

By making a contribution to this project, I certify that:

(a) The contribution was created in whole or in part by me and I
    have the right to submit it under the open source license
    indicated in the file; or

(b) The contribution is based upon previous work that, to the best
    of my knowledge, is covered under an appropriate open source
    license and I have the right under that license to submit that
    work with modifications, whether created in whole or in part
    by me, under the same open source license (unless I am
    permitted to submit under a different license), as indicated
    in the file; or

(c) The contribution was provided directly to me by some other
    person who certified (a), (b) or (c) and I have not modified
    it.

(d) I understand and agree that this project and the contribution
    are public and that a record of the contribution (including all
    personal information I submit with it, including my sign-off) is
    maintained indefinitely and may be redistributed consistent with
    this project or the open source license(s) involved.
```

End of Developer Certificate of Origin

[1]: <https://github.com/TwoPizza9621536/VideoLister>
[2]: <https://docs.github.com/authentication/managing-commit-signature-verification>
[3]: <https://developercertificate.org>
