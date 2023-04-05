import React from 'react'
import axios from 'axios';

export class Home extends React.Component {

  static displayName = Home.name;
    constructor(props) {    
      super(props);    
      this.state = {    
              file: '',    
      };    
  }

  async submit(e) {    
      e.preventDefault();    
      //const url = `https://localhost:7180/api/Post?method=1`;  
      const url = `https://localhost:7180/api/Post`;  
      const file = new FormData();
      const config = 
      {    
         headers: 
         {    
           'content-type': 'multipart/form-data',  
           Owner :1,
           method : 1,
           sign :"hello",
           subscript : "aa"
         },    
       };   
      file.append('file', e.target.files[0]);
      file.append('Owner', 1);
      file.append('method', 1);
      file.append('sign', "hello");
      file.append('subscript', "aa");    
      return axios.post(url,file,config).then(response => console.log(response.status));    
  }

  setFile(e) {    
      this.setState({ file: e.target.files[0] });  
  } 

  render() {
    return (
      <div >
          <form onSubmit={e => this.submit(e)}>  
            <input type="file" accept="image/png,image/bmp,image/svg" id="upload" hidden  onChange={e => this.submit(e)}></input>
            <label for="upload" className="button">Choose your photo</label>
          </form> 
      </div>
    );
  }
}


export default Home;
