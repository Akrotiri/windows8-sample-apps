(
    function ()
    {
        "use strict";
        var page = WinJS.UI.Pages.define
        (
            "/html/PizzaJavaScript.html",
            {
                ready: function (element, options)
                {
                    var messageText = element.querySelector("#spanOrderTotal");            
                    var listView = element.querySelector("#divListViewPizza").winControl;            
                    listView.forceLayout();

                    function itemInvokedhandler(event) { }

                    function selectionChangedHandler(event)
                    {
                        var orderTotal = 0.0;
                        //Show the message information for the item.
                        listView.selection.getItems().done
                        (
                            function (items)
                            {
                                for (var i = 0; i < items.length; i++)
                                {
                                    orderTotal += parseFloat(items[i].data.price);
                                }
                                //Print item data to the relevant message pane locations.
                                spanOrderTotal.innerText = orderTotal.toFixed(2);
                            }
                        );
                    }
                    //Register the selection changed event.
                    listView.addEventListener("selectionchanged", selectionChangedHandler, false);
                    listView.addEventListener("iteminvoked", itemInvokedhandler, false);
                }
            }
        );
    }
)();
