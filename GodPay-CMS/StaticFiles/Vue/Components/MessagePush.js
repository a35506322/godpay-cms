import globalMessage from '/StaticFiles/Vue/Components/GlobalMessage.js'
export default {
    components: {
        globalMessage
    },
    data: function () {
        return {
            globalMessages:[],
        }
    },
    mounted: function () {
        this.$emitter.on('GlobalMessage', request => {
            let { title = '', status = 'success', message = '' } = request;
            this.globalMessages.push({ title, status, message });
        })
    },
    watch: {
        globalMessages: {
            handler: function (newVal, oldVal) {
                if (newVal.length > 9) {
                    this.globalMessages = []
                }
            },
            // 物件時候需要深度監聽
            deep: true
        }
    },
    template:
        `
        <template v-if="globalMessages.length>0">
            <div class="toast-container position-absolute top-0 end-0 p-3 z-index-1030">
                <template v-for="(message,index) in globalMessages" v-bind:key="'key'+index">                
                        <global-message v-bind="message"></global-message>                         
                </template>
            </div>
        </template>
        `

}