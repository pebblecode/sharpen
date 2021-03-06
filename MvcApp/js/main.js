/*global $:true, console:true, FB:true, window:true*/
(function() {
  'use strict';

  // From http://stackoverflow.com/a/8407771/111884
  $.fn.serializeObject = function(){
      var self = this,
          json = {},
          push_counters = {},
          patterns = {
              "validate": /^[a-zA-Z][a-zA-Z0-9_]*(?:\[(?:\d*|[a-zA-Z0-9_]+)\])*$/,
              "key":      /[a-zA-Z0-9_]+|(?=\[\])/g,
              "push":     /^$/,
              "fixed":    /^\d+$/,
              "named":    /^[a-zA-Z0-9_]+$/
          };


      this.build = function(base, key, value){
          base[key] = value;
          return base;
      };

      this.push_counter = function(key){
          if(push_counters[key] === undefined){
              push_counters[key] = 0;
          }
          return push_counters[key]++;
      };

      $.each($(this).serializeArray(), function(){

          // skip invalid keys
          if(!patterns.validate.test(this.name)){
              return;
          }

          var k,
              keys = this.name.match(patterns.key),
              merge = this.value,
              reverse_key = this.name;

          while((k = keys.pop()) !== undefined){

              // adjust reverse_key
              reverse_key = reverse_key.replace(new RegExp("\\[" + k + "\\]$"), '');

              // push
              if(k.match(patterns.push)){
                  merge = self.build([], self.push_counter(reverse_key), merge);
              }

              // fixed
              else if(k.match(patterns.fixed)){
                  merge = self.build([], k, merge);
              }

              // named
              else if(k.match(patterns.named)){
                  merge = self.build({}, k, merge);
              }
          }

          json = $.extend(true, json, merge);
      });

      return json;
  };

  function submitTest() {
    $.ajax({
      type: 'POST',
      url: '/api/test',
      dataType: 'json',
      data: testForm.serializeObject(),
      success: function(data) {
        console.log(data);

        // Redirect to send page
        window.location.replace("/test/send");
      }
    });
  }


  var testForm = $("#test-form");

  testForm.find("#submit").click(function(event) {
    event.preventDefault();
    submitTest();
  });
    
  $('input', testForm).keypress(function (e) {
      if (e.which == 13) {
          submitTest();
          return false;
      }
  });
    
  var sampleData = $("#sample-data");

  sampleData.click(function() {
    testForm.find("input[name=name]").val("Science revision");
    $("#questions-0-question").val("Why does ice float");
    $("#questions-0-markingCriteria").val("1 point: Talks about density?\n1 point: Gives an example");
    $("#questions-0-points").val("2");
  });


  // Facebook
  function fbLogin() {
    FB.login(function(response) {
      if (response.authResponse) {
        console.log("Logged in");
      } else {
        console.log("Cancelled log in");
      }
    });
  }

  function initSendTest() {
    $(".send-test").click(function(event) {
      event.preventDefault();
      var elem = event.target,
          elemId = $(elem).data("id"),
          testName = $(elem).text();


      FB.ui({
        method: 'send',
        name: testName + ' test',
        link: 'http://sharpen.apphb.com/answer/' + elemId
      },
      function(response) {
        console.log(response);
        if (response && response.success === true) {
          console.log('Post was published.');
        } else {
          console.log('Post was not published.');
        }
      });
    });
  }

  // Initialisation code
  // Called after facebook is initialised
  window.fbInit = function fbInit() {

    FB.getLoginStatus(function(response) {
      if (response.status === 'connected') {
        console.log("connected");
        initSendTest();
      } else if (response.status === 'not_authorized') {
        console.log("not authorized");
        fbLogin();
      } else {
        console.log("not logged in");
        fbLogin();
      }
    });
  };

})();