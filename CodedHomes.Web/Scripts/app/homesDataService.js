var httpVerbs = {
    POST: 'POST',
    PUT: 'PUT',
    GET: 'GET',
    DEL: 'DELETE'
};

var homesDataService = (function () {
    // data service
    var ds = {
        // send the request to the server
        commit: function (type, url, data) {
            // remove 'id' member to prepare for INSERT
            if (type === httpVerbs.POST) {
                delete data['id'];
            }

            return $.ajax({
                type: type,
                url: url,
                data: data,
                dataType: 'json'
            });
        },
        // delete function
        del: function (data) {
            return this.commit(httpVerbs.DEL, '/api/homes/' + data.id);
        },
        // post or put
        save: function (data) {
            var type = httpVerbs.POST,
                url = '/api/homes';

            if (data.id > 0) {
                type = httpVerbs.PUT;
                url += '/' + data.id;
            }

            return this.commit(type, url, data);
        },
        saveImage: function (data) { 
            return $.ajax({
                type: httpVerbs.POST,
                url: '/homes/uploadimage',
                processData: false,
                contentType: false,
                data: data
            });
        }
    };

    // run under the context of the ds context
    _.bindAll(ds, 'del', 'save');

    // make it public and return the promise
    return {
        save: ds.save,
        del: ds.del,
        saveImage: ds.saveImage
    };

})();