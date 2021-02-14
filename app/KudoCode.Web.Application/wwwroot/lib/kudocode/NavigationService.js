define(['underscore'], function (_) {

        //window.localStorage.clear();
        this.storeName = ""//= "navStore";
        this.homeNode = "";//= {title: "Home", uri: "\\Portfolios"};
        this.instance = this;

        var Register = function (storeName, homeUrl) {
            instance.storeName = storeName;
            instance.homeNode = homeUrl;
            
        };


        var myStorage = window.localStorage;

        var GoTo = function (title, url) {
            push(title, url);
            window.location.href = url;
        };
        var GoBack = function () {
            window.location.href = pop();
        };

        var GetNavItems = function () {
            var urlList = getList(myStorage, storeName, homeNode);
            return _.last(urlList, 8);
        };

        function pop() {
            var urlList = getList(myStorage, storeName, homeNode);

            if (urlList.length > 1)
                urlList.pop(); //pop current 
            var uri = urlList[urlList.length - 1].uri;
            set(myStorage, storeName, urlList);
            return uri;
        }

        function push(title, uri) {
            var urlList = getList(myStorage, storeName, homeNode);

            var idx = _.findIndex(urlList, {
                title: title
            });

            if (idx > -1)
                urlList = _.first(urlList, idx);

            urlList = rest(urlList, homeNode);
            if (urlList[urlList.length - 1].uri !== uri)
                urlList.push({title: title, uri: uri});

            set(myStorage, storeName, urlList);
        }

        return {
            GoTo: GoTo,
            GoBack: GoBack,
            GetNavItems: GetNavItems,
            Register: Register,
        };
    }
);

function rest(urlList, homeNode) {
    if (urlList === undefined || urlList === null || urlList.length === 0) {
        urlList = [homeNode];
    }
    return urlList;
}

function getList(myStorage, storeName, homeNode) {
    try {
        var urlList = JSON.parse(myStorage.getItem(storeName));
    } catch (e) {
        urlList = undefined;
    }

    urlList = rest(urlList, homeNode);
    return urlList;
}

function set(myStorage, storeName, urlList) {

    myStorage.setItem(storeName, JSON.stringify(urlList));

}


