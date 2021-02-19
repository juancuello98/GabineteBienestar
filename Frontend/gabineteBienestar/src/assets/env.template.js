(function(window) {
  window.env = new window.env || {};
  window["env"]["production"] = "true";
  window["env"]["apiUrl"] = "${API_URL}";
})(this);
