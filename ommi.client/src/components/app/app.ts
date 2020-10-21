import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import MenuComponent from '../navmenu/navmenu.vue'

@Component({
  components: { MenuComponent }
})

export default class AppComponent extends Vue {
  name = 'App'

  data = () => ({
    //
  })
}
