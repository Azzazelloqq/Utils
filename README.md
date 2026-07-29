# Utils for Unity

> Small focused extensions for common Unity and C# tasks.

`Utils` is a lightweight utility module. It contains extension methods for UI
alpha, TextMeshPro alpha, random float ranges and cancellation-aware async UI
subscriptions.

## Installation

```bash
git submodule add https://github.com/Azzazelloqq/Utils.git Assets/Utils
```

Or add to `Packages/manifest.json`:

```json
"com.azzazello.utils": "https://github.com/Azzazelloqq/Utils.git"
```

The module requires TextMeshPro and supports Unity `2020.3` and newer.

## UI alpha

```csharp
using Utils;

image.SetAlpha(0.5f);
titleText.SetTextAlpha(0.8f);
```

`SetAlpha` works with `UnityEngine.UI.Image`; `SetTextAlpha` works with
`TMP_Text`.

## Random float range

```csharp
using System;
using Utils;

var random = new Random();
var speed = random.NextFloat(1.5f, 3.0f);
```

## Async button subscription

`SubscribeClickAsync` returns `IDisposable`, so the listener can be removed
with the owner lifetime:

```csharp
using Utils.AsyncSubscribe;

_subscription = playButton.SubscribeClickAsync(
    async token => await StartGameAsync(token),
    destroyCancellationToken);

// Later
_subscription.Dispose();
```

The callback is not invoked after cancellation. Exceptions other than
`OperationCanceledException` are logged through Unity.

## Contents

| Type | Purpose |
| --- | --- |
| `ImageExtensions` | Set an `Image` alpha channel. |
| `TMPExtensions` | Set a TextMeshPro alpha channel. |
| `RandomExtensions` | Generate a float in a range from `System.Random`. |
| `ActionAsyncExtensions` | Subscribe an async callback to an `Action`. |
| `ButtonExtensions` | Subscribe an async callback to `Button.onClick`. |
| `Unsubscriber` | Disposable callback unsubscription helper. |
