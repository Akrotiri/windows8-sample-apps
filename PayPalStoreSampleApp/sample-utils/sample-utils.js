(function () {
    var lastError = "";
    var lastStatus = "";
    var ScenarioInput = WinJS.Class.define(
        function (element, options) {
        element.winControl = this;
        this.element = element;

        new WinJS.Utilities.QueryCollection(element)
                    .setAttribute("role", "main")
                    .setAttribute("aria-labelledby", "inputLabel");
        element.id = "input";

        this.addInputLabel(element);
        this.addDetailsElement(element);
        this.addScenariosPicker(element);
    }, {
        addInputLabel: function (element) {
            var label = document.createElement("h2");
            label.textContent = "Input";
            label.id = "inputLabel";
            element.parentNode.insertBefore(label, element);
        },
        addScenariosPicker: function (parentElement) {
            var scenarios = document.createElement("div");
            scenarios.id = "scenarios";
            var control = new ScenarioSelect(scenarios);

            parentElement.insertBefore(scenarios, parentElement.childNodes[0]);
        },

        addDetailsElement: function (sourceElement) {
            var detailsDiv = this._createDetailsDiv();
            while (sourceElement.childNodes.length > 0) {
                detailsDiv.appendChild(sourceElement.removeChild(sourceElement.childNodes[0]));
            }
            sourceElement.appendChild(detailsDiv);
        },
        _createDetailsDiv: function () {
            var detailsDiv = document.createElement("div");

            new WinJS.Utilities.QueryCollection(detailsDiv)
                        .addClass("details")
                        .setAttribute("role", "region")
                        .setAttribute("aria-labelledby", "descLabel")
                        .setAttribute("aria-live", "assertive");

            var label = document.createElement("h3");
            label.textContent = "Description";
            label.id = "descLabel";

            detailsDiv.appendChild(label);
            return detailsDiv;
        },
    }
    );

    var ScenarioOutput = WinJS.Class.define(
        function (element, options) {
        element.winControl = this;
        this.element = element;
        new WinJS.Utilities.QueryCollection(element)
                    .setAttribute("role", "region")
                    .setAttribute("aria-labelledby", "outputLabel")
                    .setAttribute("aria-live", "assertive");
        element.id = "output";

        this._addOutputLabel(element);
        this._addStatusOutput(element);
    }, {
        _addOutputLabel: function (element) {
            var label = document.createElement("h2");
            label.id = "outputLabel";
            //label.textContent = "Output";
            element.parentNode.insertBefore(label, element);
        },
        _addStatusOutput: function (element) {
            var statusDiv = document.createElement("div");
            statusDiv.id = "statusMessage";
            element.insertBefore(statusDiv, element.childNodes[0]);
        }
    }
    );
    
    var currentScenarioUrl = null;

    WinJS.Navigation.addEventListener("navigating", function (evt) {
        currentScenarioUrl = evt.detail.location;
    });

    WinJS.log = function (message, tag, type) {
        var isError = (type === "error");
        var isStatus = (type === "status");

        if (isError || isStatus) {
            var statusDiv = /* @type(HTMLElement) */ document.getElementById("statusMessage");
            if (statusDiv) {
                statusDiv.innerText = message;
                if (isError) {
                    lastError = message;
                    statusDiv.style.color = "blue";
                } else if (isStatus) {
                    lastStatus = message;
                    statusDiv.style.color = "green";
                }
            }
        }
    };

    var ScenarioSelect = WinJS.UI.Pages.define("/sample-utils/scenario-select.html", {
        ready: function (element, options) {
            var that = this;
            var selectElement = WinJS.Utilities.query("#scenarioSelect", element);
            this._selectElement = selectElement[0];

            SdkSample.scenarios.forEach(function (s, index) {
                that._addScenario(index, s);
            });

            selectElement.listen("change", function (evt) {
                var select = evt.target;
                if (select.selectedIndex >= 0) {
                    var newUrl = select.options[select.selectedIndex].value;
                    WinJS.Navigation.navigate(newUrl).then(function () {
                        setImmediate(function () {
                            document.getElementById("scenarioSelect").setActive();
                        });
                    });
                }
            });
            selectElement[0].size = (SdkSample.scenarios.length > 5 ? 5 : SdkSample.scenarios.length);
            if (SdkSample.scenarios.length === 1) {
                selectElement[0].setAttribute("multiple", "multiple");
            }
        },

        _addScenario: function (index, info) {
            var option = document.createElement("option");
            if (info.url === currentScenarioUrl) {
                option.selected = "selected";
            }
            option.text = (index + 1) + ") " + info.title;
            option.value = info.url;
            this._selectElement.appendChild(option);
        }
    });

    function activated(e) {
        WinJS.Utilities.query("#featureLabel")[0].textContent = SdkSample.sampleTitle;
    }

    WinJS.Application.addEventListener("activated", activated, false);

    WinJS.Namespace.define("SdkSample", {
        ScenarioInput: ScenarioInput,
        ScenarioOutput: ScenarioOutput
    });

    document.TestSdkSample = {
        getLastError: function () {
            return lastError;
        },

        getLastStatus: function () {
            return lastStatus;
        },

        selectScenario: function (scenarioID) {
            scenarioID = scenarioID >> 0;
            var select = document.getElementById("scenarioSelect");
            var newUrl = select.options[scenarioID - 1].value;
            WinJS.Navigation.navigate(newUrl).then(function () {
                setImmediate(function () {
                    document.getElementById("scenarioSelect").setActive();
                });
            });
        }
    };
})();
