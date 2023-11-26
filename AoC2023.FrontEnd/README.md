design goals

make it obvious

- apis return component
- pages use components in markup (first load)

apis need
  - view (razor)
  - data

views need
  - view (razor)
  - data

attempts to combine view and data into one class (ICounterApi)
  (GetCounter() used in routehandler and html rendering)
has been... mixed
  - degrades razor experience
  - code to create raw html is a bit verbose. Not sure maintence / perf cost

currently, tension in CounterApi class b/c AddToApp() feels more like in static class
However, cannot use constructors in static class to do dependency injection  
