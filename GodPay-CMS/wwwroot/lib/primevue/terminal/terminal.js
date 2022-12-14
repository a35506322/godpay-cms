this.primevue = this.primevue || {};
this.primevue.terminal = (function (TerminalService, vue) {
    'use strict';

    function _interopDefaultLegacy (e) { return e && typeof e === 'object' && 'default' in e ? e : { 'default': e }; }

    var TerminalService__default = /*#__PURE__*/_interopDefaultLegacy(TerminalService);

    var script = {
        name: 'Terminal',
        props: {
            welcomeMessage: {
                type: String,
                default: null
            },
            prompt: {
                type: String,
                default: null
            }
        },
        data() {
            return {
                commandText: null,
                commands: []
            }
        },
        mounted() {
            TerminalService__default['default'].on('response', this.responseListener);
            this.$refs.input.focus();
        },
        updated() {
            this.$el.scrollTop = this.$el.scrollHeight;
        },
        beforeUnmount() {
            TerminalService__default['default'].off('response', this.responseListener);
        },
        methods: {
            onClick() {
                this.$refs.input.focus();
            },
            onKeydown(event) {
                if (event.keyCode === 13 && this.commandText) {
                    this.commands.push({text: this.commandText});
                    TerminalService__default['default'].emit('command', this.commandText);
                    this.commandText = '';
                }
            },
            responseListener(response) {
                this.commands[this.commands.length - 1].response = response;
            }
        }
    };

    const _hoisted_1 = { key: 0 };
    const _hoisted_2 = { class: "p-terminal-content" };
    const _hoisted_3 = { class: "p-terminal-prompt" };
    const _hoisted_4 = { class: "p-terminal-command" };
    const _hoisted_5 = { class: "p-terminal-response" };
    const _hoisted_6 = { class: "p-terminal-prompt-container" };
    const _hoisted_7 = { class: "p-terminal-prompt" };

    function render(_ctx, _cache, $props, $setup, $data, $options) {
      return (vue.openBlock(), vue.createBlock("div", {
        class: "p-terminal p-component",
        onClick: _cache[3] || (_cache[3] = (...args) => ($options.onClick && $options.onClick(...args)))
      }, [
        ($props.welcomeMessage)
          ? (vue.openBlock(), vue.createBlock("div", _hoisted_1, vue.toDisplayString($props.welcomeMessage), 1))
          : vue.createCommentVNode("", true),
        vue.createVNode("div", _hoisted_2, [
          (vue.openBlock(true), vue.createBlock(vue.Fragment, null, vue.renderList($data.commands, (command, i) => {
            return (vue.openBlock(), vue.createBlock("div", {
              key: command.text + i.toString()
            }, [
              vue.createVNode("span", _hoisted_3, vue.toDisplayString($props.prompt), 1),
              vue.createVNode("span", _hoisted_4, vue.toDisplayString(command.text), 1),
              vue.createVNode("div", _hoisted_5, vue.toDisplayString(command.response), 1)
            ]))
          }), 128))
        ]),
        vue.createVNode("div", _hoisted_6, [
          vue.createVNode("span", _hoisted_7, vue.toDisplayString($props.prompt), 1),
          vue.withDirectives(vue.createVNode("input", {
            ref: "input",
            type: "text",
            "onUpdate:modelValue": _cache[1] || (_cache[1] = $event => ($data.commandText = $event)),
            class: "p-terminal-input",
            autocomplete: "off",
            onKeydown: _cache[2] || (_cache[2] = (...args) => ($options.onKeydown && $options.onKeydown(...args)))
          }, null, 544), [
            [vue.vModelText, $data.commandText]
          ])
        ])
      ]))
    }

    function styleInject(css, ref) {
      if ( ref === void 0 ) ref = {};
      var insertAt = ref.insertAt;

      if (!css || typeof document === 'undefined') { return; }

      var head = document.head || document.getElementsByTagName('head')[0];
      var style = document.createElement('style');
      style.type = 'text/css';

      if (insertAt === 'top') {
        if (head.firstChild) {
          head.insertBefore(style, head.firstChild);
        } else {
          head.appendChild(style);
        }
      } else {
        head.appendChild(style);
      }

      if (style.styleSheet) {
        style.styleSheet.cssText = css;
      } else {
        style.appendChild(document.createTextNode(css));
      }
    }

    var css_248z = "\n.p-terminal {\n    height: 18rem;\n    overflow: auto;\n}\n.p-terminal-prompt-container {\n    display: -webkit-box;\n    display: -ms-flexbox;\n    display: flex;\n    -webkit-box-align: center;\n        -ms-flex-align: center;\n            align-items: center;\n}\n.p-terminal-input {\n    -webkit-box-flex: 1;\n        -ms-flex: 1 1 auto;\n            flex: 1 1 auto;\n    border: 0 none;\n    background-color: transparent;\n    color: inherit;\n    padding: 0;\n    outline: 0 none;\n}\n.p-terminal-input::-ms-clear {\n    display: none;\n}\n";
    styleInject(css_248z);

    script.render = render;

    return script;

}(primevue.terminalservice, Vue));
