import React from "react"
import {Link} from "react-router-dom"
import axios from "axios"
import Loader from "react-loader-spinner"
import {login, getUserById} from "../../../functions"
import ReactGrid from "../../ReactGrid"

import "../../../assets/scss/view-avatar.scss"

class ViewAvatar extends React.Component {
	constructor(props){
		super(props)
		this.state = {
			columns: [
				{name: 'avatar', title: 'Avatar'},
				{name: 'level', title: 'Level'},
				{name: 'karma', title: 'Karma'},
				{name: 'sex', title: 'Sex'},
				{name: 'created', title: 'Created'},
				{name: 'modified', title: 'Last Beamed In'},
				{name: 'online', title: 'Online'},
			],
			rows: [],
			loading: true,
			loggedIn: true
		}
	}

	async componentDidMount() {
        var token, refresh, credentials;

        //If user object exists in localstorage, get the refresh token
        //and the jwtToken
        if (localStorage.getItem("user")) {
            credentials = JSON.parse(localStorage.getItem("credentials"));
            let avatar = await login(credentials);
            if (avatar !== -1) {
                token = avatar.jwtToken;
                refresh = avatar.refreshToken;
            }
        }

        //else (for now) show an alert and redirect to home
        else {
            // alert("not logged in");
            this.setState({ loggedIn: false });
        }
        let config = {
            method: "get",
            url: "https://api.oasisplatform.world/api/avatar/GetAll",
            headers: {
                Authorization: `Bearer ${token}`,
                Cookie: `refreshToken=${refresh}`,
            },
        };
        this.setState({ loading: true });
        axios(config)
            .then(async (response) => {
                let avatars = []
                for (let i = 0; i <= response.data.length - 1; i++){
                	const data = response.data[i]
                    const id = data.id;
                    let tkn = {jwt: token}
                    const user = await getUserById(id, tkn)
                    console.log(user)
                	const avatar = {
                		avatar: data.username,
                		level: data.level,
                		karma: data.karma,
                		sex: 'Male',
                		created: user.createdDate,
                		modified: user.modifiedDate,
                		online: data.isBeamedIn ? 'Yes' : 'No'
                	}
                	avatars.push(avatar)
                }

                this.setState({ rows: avatars });
                // console.log(avatars);
                this.setState({ loading: false });
                this.setState({ loggedIn: true });
            })
            .catch((error) => {
                this.setState({ loading: true });
                // console.log(error.response);
            });
    }

	render(){
		return (
			<div className="popup-container">
                <div className="avatar">
                    <Link to="/" className="popup-cancel">
                        <span className="form-cross-icon">
                            <i className="fa fa-times"></i>
                        </span>
                    </Link>
                {this.state.loggedIn ? (
                	<>
                        {this.state.loading ? (
                            <Loader type="Oval" height={30} width={30} color="#fff" />
                        ) : 
                            <ReactGrid
                                rows={this.state.rows}
                                columns={this.state.columns}
                            />
                        }
                     </>
                ) : (
                    <h1>You are not logged in! </h1>
                )}
                </div>
            </div>
		)
	}
}

export default ViewAvatar