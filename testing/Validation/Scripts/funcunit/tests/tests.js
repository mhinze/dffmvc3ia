module("later", {
    setup: function() {
        // opens the page you want to test
        S.open("/Dates/ValidUsername");
    }
});

test("page has content", function() {
    ok(S("body *").size(), "There be elements in that there body");
});

test("fields are required", function () {
    S('button').click(function () {
        ok(S('span[for=Earlier]').html() == "The Earlier field is required.", "earlier message appears");
        ok(S('span[for=Later]').html() == "The Later field is required.", "later message appears");
    });
});

test("later date must be later", function () {
    S('input#Earlier').type('12/2/2001');
    S('input#Later').type('12/1/2001');
    S('input#Earlier').click(function () {
        ok(S('span[for=Later]').html() == "'Later' must be after 'Earlier' (via client validation)", "later message appears");
    });
    
});