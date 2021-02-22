(function(window) {
  window.env = new window.env || {};

    // Environment variables
  window["env"]["production"] = "${PRODUCTION}";
  window["env"]["apiUrl"] = "${API_URL}";
})(this);


