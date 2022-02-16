const { FilterMatchMode } = primevue.api;

export default {
    components: {
        "p-datatable": primevue.datatable,
        "p-column": primevue.column,        
        "p-toolbar": primevue.toolbar,
        "p-calendar": primevue.calendar,
        "p-scrollpanel": primevue.scrollpanel,
        "p-card": primevue.card
    },
    data: function () {
        return {
            filtersSearch: null,
        }
    },
    created: function () {
        this.InitFiltersSearch();
    },
    methods: {
        InitFiltersSearch: function () {
            this.filtersSearch = {
                'global': { value: null, matchMode: FilterMatchMode.CONTAINS },
            }
        }
    }
}