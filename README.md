# REST API C# Examples
This is Arthika's repository for examples, sample code written in C# that demonstrates in a simple way how to use our REST API.

* getAccount
* getInterface
* pricePolling
* priceStreaming
* orderPolling
* orderStreaming
* positionPolling
* positionStreaming
* setOrder
* cancelOrder
* modifyOrder
* getHistoricalPrice
* authentication

### Pre-requisites:
You need to install Visual Studio. 

### How to:

**1. Clone this repository to the location of your choice** 

The repository contains all the examples listed above together with the classes needed. 

**2. Modify config.properties file with your settings** 

```
domain=http://demo.arthikatrading.com
user=demo
password=demo
```

**3. Modify the following lines in the Java program you would like to run.** 

From here on we will assume it is priceStreaming.java.
```
request.getPrice = new getPriceRequest(user, token, new List<string> { "EUR/USD", "GBP/USD" }, null, "tob", 1, interval);
```

In case you want to disable ssl protocol, change the following line:
```
private static bool ssl = true;
```

**4. Generate executable file.**


**5. Run executable file.**
```javascript
$ REST-API-CSharp-Examples

Choose option: 
 0: Exit
 1: PriceStreaming
 2: PricePolling
 3: PositionStreaming
 4: PositionPolling
 5: OrderStreaming
 6: OrderPolling
 7: SetOrder
 8: ModifyOrder
 9: CancelOrder
10: GetAccount
11: GetInterface
12: GetHistoricalPrice
```

or

```javascript
$ REST-API-CSharp-Examples 1

Response timestamp: 1441712414.982956 Contents:
Security: EUR/USD Price: 1.11618 Side: ask Liquidity: 1000000
Security: EUR/USD Price: 1.11613 Side: bid Liquidity: 1000000
Response timestamp: 1441712415.983567 Contents:
Heartbeat!
Response timestamp: 1441712416.194543 Contents:
Security: EUR/USD Price: 1.11618 Side: ask Liquidity: 1000000
Security: EUR/USD Price: 1.11614 Side: bid Liquidity: 500000
```


