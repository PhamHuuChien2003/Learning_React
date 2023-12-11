import './Container.css'


import LeftPanel from './Left-panel/Left-panel'
import MiddlePanel from './Middle-panel/Middle-panel'
import RightPanel from './Right-panel/Right-panel'


export default function Container() {


    return(
        <div class="container">
          <LeftPanel/>
          <MiddlePanel/>
          <RightPanel/>  
        </div>
    )
}