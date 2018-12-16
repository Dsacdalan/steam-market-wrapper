# Steam Market Wrapper

The Steam Market does not have an offical API, but they do have a few endpoints that return JSON.

This library will provide a wrapper for these hidden APIs.

* [GetItemAsync](#GetItemAsync(int,-string,-Currency.Code))
* [Classes](#classes)
  * [Item](#item)

## SteamMarket()

Creates a new instance of the Steam Market Wrapper with its own HttpClient instance.

```cs
public SteamMarket ();
```

## SteamMarket(HttpClient)

Creates a new instance of the Steam Market Wrapper and uses a previously created HttpClient instance.

```cs
public SteamMarket(System.Net.Http.HttpClient httpClient);
```

### Parameters

**httpClient** HttpClient

The HttpClient to make the Steam Market requests.

## GetItemAsync(int, string, Currency.Code)

Gets an [Item](#item) from the Steam Market.

```cs
public async Task<Item> GetItemAsync(int appid, string marketHashName, Currency.Code currency = Currency.Code.DEFAULT)
```

### Parameters

**appid** int

The Steam game appid.

**marktHashName** string

The hash name for a specific Steam Market item.

**currency** [Currency.Code](#currency.code)

The Steam Market Currency code. Defaults to DEFAULT (0) if none is provided.

###  Returns

Task\<[Item](#item)>

The task object representing the asynchronous operation.

## Classes

### Item

Contains the raw data from the request as well as some casted fields:

* **Success** (_bool_): Status of the request
* **Lowest_Price** (_string_): The current lowest selling price
* **Volume** (_string_): The total number of sell requests
* **Median_Price** (_string_): The middle price of all sell requests
* **LowestPriceDouble** (_double_): Casted double of Lowest_Price; defaults to 0.00 if cast fails
* **VolumeInt** (_int_): Casted int of Volume; defaults to 0 if cast fails
* **MedianPriceDouble** (_double_): Catsed double of Median_Price; defaults to 0.00 if cast fails

## Currency.Code

Enumeration of Steam Market currency codes.

* DEFAULT
* USA
* UK

## Help Needed

Do you know of any endpoints that this library does not implement?
If you do, please create an issue so I can implement it.
