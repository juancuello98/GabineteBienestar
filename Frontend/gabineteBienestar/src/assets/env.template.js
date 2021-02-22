(function(window) {
  window.env = window.env || {};

    // Environment variables
  window["env"]["production"] = "${PRODUCTION}";
  window["env"]["api_url"] = "${API_URL}";
})(this);


