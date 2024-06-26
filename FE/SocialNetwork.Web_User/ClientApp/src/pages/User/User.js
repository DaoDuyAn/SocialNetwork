import { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useParams, useNavigate, useSearchParams } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBookmark as regularBookmark } from '@fortawesome/free-regular-svg-icons';
import { faBookmark as solidBookmark, faPenToSquare, faCircleCheck } from '@fortawesome/free-solid-svg-icons';
import classNames from 'classnames/bind';

import PostItem from '~/components/PostItem';
import styles from './User.module.scss';

const cx = classNames.bind(styles);

function User() {
    const navigate = useNavigate();
    const [searchParams, setSearchParams] = useSearchParams();
    const { username } = useParams();
    const initialTab = searchParams.get('tab') || 'createdPosts';
    const initialPage = parseInt(searchParams.get('page')) || 1;

    const userName = localStorage.getItem('userName') ?? null;
    const userId = localStorage.getItem('userId') ?? null;

    const [currentUser, setCurrentUser] = useState(localStorage.getItem('accessToken') ?? null);
    const [dataUser, setDataUser] = useState({});
    const [posts, setPosts] = useState([]);
    const [postsSaved, setPostsSaved] = useState(null);
    const [visible, setVisible] = useState(true);

    const [tab, setTab] = useState(initialTab);
    const [page, setPage] = useState(initialPage);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(
                    `https://localhost:44379/api/v1/GetUserByUserName/username/${username}`,
                );
                setDataUser(response.data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, [username]);

    useEffect(() => {
        const fetchPosts = async () => {
            try {
                const response = await axios.get(`https://localhost:44379/api/v1/GetPostsByUserName`, {
                    params: {
                        tab: tab,
                        page: page,
                        userName: username,
                    },
                });
                setPosts(response.data.postResponse);
            } catch (error) {
                console.error('Error fetching posts:', error);
            }
        };

        fetchPosts();
    }, [tab, page, username]);

    // useEffect(() => {
    //     const fetchPosts = async () => {
    //         try {
    //             const response = await axios.get(`https://localhost:44379/api/v1/GetPostsByUserId/userId/${userId}`);
    //             setPosts(response.data);
    //         } catch (error) {
    //             console.error('Error fetching posts:', error);
    //         }
    //     };

    //     fetchPosts();
    // }, []);

    // useEffect(() => {
    //     const fetchData = async () => {
    //         try {
    //             const response = await axios.get(
    //                 `https://localhost:44379/api/v1/GetPostsByUserId/userId/${userId}`,
    //             );
    //             setPosts(response.data);
    //         } catch (error) {
    //             console.error('Error fetching data:', error);
    //         }
    //     };

    //     fetchData();
    // }, []);

    const getUser = () => {
        // call API
    };

    const getPostsByUser = () => {
        // call API
    };

    useEffect(() => {
        // Cập nhật state `tab` khi URL thay đổi
        const currentTab = searchParams.get('tab') || 'createdPosts';
        setTab(currentTab);
    }, [searchParams]);

    const handelUnFollow = (e) => {};

    const handelFollow = (e) => {};

    useEffect(() => {
        window.scrollTo({
            top: 0,
            left: 0,
        });
    }, []);

    return (
        <div className={cx('main')}>
            <div className={cx('user')}>
                <div className={cx('user__cover')}>
                    <img
                    src={
                        dataUser.coverImagePath !== ''
                            ? dataUser.coverImagePath
                            : 'https://images.spiderum.com/sp-cover/27dc3ea0ea5111eebf8b5ffe6a1c5c77.jpeg'
                    }
                    alt="" />
                </div>
                <div className={cx('user__profile')}>
                    <div className={cx('user__profile-content')}>
                        <div className={cx('user__profile-sidebar')}>
                            <div
                                className={cx('user__profile-dynamic', {
                                    'user__profile-visible': visible,
                                    'user__profile-invisible': !visible,
                                })}
                                style={
                                    visible
                                        ? { height: '800px', maxHeight: '50%', top: '160px' }
                                        : { height: '800px', maxHeight: '50%', top: '-200px' }
                                }
                            >
                                <div className={cx('user__profile-widget')}>
                                    <div className={cx('user__profile-widget-body')}>
                                        <div className={cx('user__profile-widget-content')}>
                                            <div className={cx('user__profile-widget-avt')}>
                                                <Link to="/" className={cx('user__profile-widget-avt-link')}>
                                                    <img
                                                        src={
                                                            dataUser.avatarImagePath !== ''
                                                                ? dataUser.avatarImagePath
                                                                : 'https://www.gravatar.com/avatar/8f9a66cc24f92fb53bc4f112cf5a3fe2?d=wavatar&f=y'
                                                        }
                                                        alt=""
                                                    />
                                                </Link>
                                            </div>
                                            <h1 className={cx('user__profile-widget-disname')}>
                                                <Link to="/">{dataUser.fullName}</Link>
                                            </h1>
                                            <p className={cx('user__profile-widget-username')}>
                                                <Link to="/">@{dataUser.userName}</Link>
                                            </p>
                                            <div className={cx('user__profile-widget-bio')}>{dataUser.description}</div>
                                            {/* <Link className={cx('user__edit')} to="/user/settings">
                                                Chỉnh sửa trang cá nhân
                                            </Link> */}

                                            {/* <div className={cx('user__profile-widget-button')}>
                                                <div onClick={() => window.location.reload(false)}>
                                                    <button
                                                        className={cx('user__profile-widget-button-item')}
                                                        onClick={handelUnFollow}
                                                    >
                                                        <FontAwesomeIcon className={cx('follow-icon')} icon={faCircleCheck} />
                                                       
                                                        <span className={cx('follow-text')}>Đang theo dõi</span>
                                                    </button>
                                                </div>
                                            </div>

                                            <div className={cx('user__profile-widget-button')}>
                                                <div onClick={() => window.location.reload(false)}>
                                                    <button
                                                        className={cx('user__profile-widget-button-item')}
                                                        onClick={handelFollow}
                                                    >
                                                        <span className={cx('follow-text')}>Theo dõi</span>
                                                    </button>
                                                </div>{' '}
                                            </div> */}
                                            {dataUser.userName === userName ? (
                                                <Link className={cx('user__edit')} to="/user/settings">
                                                    Chỉnh sửa trang cá nhân
                                                </Link>
                                            ) : (
                                                <div className={cx('user__profile-widget-button')}>
                                                    <div onClick={() => window.location.reload(false)}>
                                                        <button
                                                            className={cx('user__profile-widget-button-item')}
                                                            onClick={handelUnFollow}
                                                        >
                                                            <FontAwesomeIcon
                                                                className={cx('follow-icon')}
                                                                icon={faCircleCheck}
                                                            />

                                                            <span className={cx('follow-text')}>Đang theo dõi</span>
                                                        </button>
                                                    </div>
                                                </div>
                                                // <div className={cx('user__profile-widget-button')}>
                                                //      {currentUser ? (
                                                //         dataUser.id !== userId ? (
                                                //             <div onClick={() => window.location.reload(false)}>
                                                //                 <button
                                                //                     className={cx(
                                                //                         'user__profile-widget-button-item follow',
                                                //                     )}
                                                //                     onClick={handelUnFollow}
                                                //                 >
                                                //                     <span className={cx('follow-icon')}>
                                                //                         <i class="bx bxs-check-circle"></i>
                                                //                     </span>
                                                //                     <span className={cx('follow-text')}>
                                                //                         Đang Theo dõi
                                                //                     </span>
                                                //                 </button>
                                                //             </div>
                                                //         ) : (
                                                //             <div onClick={() => window.location.reload(false)}>
                                                //                 <button
                                                //                     className={cx('user__profile-widget-button-item')}
                                                //                     onClick={handelFollow}
                                                //                 >
                                                //                     <span>Theo dõi</span>
                                                //                 </button>
                                                //             </div>
                                                //         )
                                                //     ) : (
                                                //         <Link to="/login">
                                                //             <button className={cx('user__profile-widget-button-item')}>
                                                //                 <span>Theo dõi</span>
                                                //             </button>
                                                //         </Link>
                                                //     )}
                                                //     <button
                                                //         className={cx('user__profile-widget-button-item')}
                                                //         // onClick={handelClickMes}
                                                //     >
                                                //         <span>Nhắn tin</span>
                                                //     </button>
                                                // </div>
                                            )}
                                            <div className={cx('user__profile-widget-stats')}>
                                                <div>
                                                    <p className={cx('label')}>Người theo dõi</p>
                                                    <p className={cx('value')}>
                                                        {currentUser?.user?.followers
                                                            ? currentUser?.user?.followers.length
                                                            : '0'}
                                                    </p>
                                                </div>
                                                <div>
                                                    <p className={cx('label')}>Đang theo dõi</p>
                                                    <p className={cx('value')}>
                                                        {currentUser?.user?.following
                                                            ? currentUser?.user?.following.length
                                                            : '0'}
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className={cx('user__profile-main')}>
                            <div className={cx('user__profile-tabs')}>
                                <div className={cx('user__profile-tabs-container')}>
                                    <div className={cx('user__profile-tabs-content')}>
                                        <div className={cx('user__profile-tabs-tab')}>
                                            <Link
                                                className={cx('user__profile-tabs-link', {
                                                    active: tab === 'createdPosts',
                                                })}
                                                to={`/user/${username}?tab=createdPosts`}
                                            >
                                                <FontAwesomeIcon
                                                    className={cx('user__profile-tabs-icon')}
                                                    icon={faPenToSquare}
                                                />
                                                <span>Bài viết</span>
                                            </Link>
                                            {/* {currentUser._id === currentUser.user._id ? (
                                                <Link
                                                    className={cx('user__profile-tabs-link', {
                                                        active: tab === 'savedPosts',
                                                    })}
                                                    to={`/user/${currentUser.user.userName}?tab=savedPosts`}
                                                >
                                                    <span>Bài viết đã lưu</span>
                                                </Link>
                                            ) : null} */}
                                            {/* <Link
                                                className={cx('user__profile-tabs-link', {
                                                    active: tab === 'savedPosts',
                                                })}
                                                to={`/user/${username}?tab=savedPosts`}
                                            >
                                                <FontAwesomeIcon
                                                    className={cx('user__profile-tabs-icon')}
                                                    icon={regularBookmark}
                                                />
                                                <span>Đã lưu</span>
                                            </Link> */}

                                            {username === userName && (
                                                <Link
                                                    className={cx('user__profile-tabs-link', {
                                                        active: tab === 'savedPosts',
                                                    })}
                                                    to={`/user/${username}?tab=savedPosts`}
                                                >
                                                    <FontAwesomeIcon
                                                        className={cx('user__profile-tabs-icon')}
                                                        icon={regularBookmark}
                                                    />
                                                    <span>Đã lưu</span>
                                                </Link>
                                            )}
                                        </div>
                                    </div>
                                </div>
                            </div>
                            {tab === 'savedPosts' && username === userName ? (
                                <div className={cx('user__profile-posts')}>
                                    <div className={cx('user__profile-posts-top')}>
                                        <div className={cx('user__profile-posts-all-body')}>
                                            <div className={cx('user__profile-posts-all-content')}>
                                                <div className={cx('grid')}>
                                                    {/* {postsSaved
                                                        ? postsSaved.length > 0
                                                            ? postsSaved.map((post) => (
                                                                  <PostItem post={post} key={post._id} />
                                                              ))
                                                            : 'Bạn chưa lưu bài viết nào'
                                                        : ''} */}
                                                    <div className={cx('empty')}>Bạn chưa lưu bài viết nào</div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            ) : posts?.length !== 0 ? (
                                <div className={cx('user__profile-posts')}>
                                    {/* <div className={cx('user__profile-posts-top')}>
                                        <div className={cx('user__profile-posts-head')}>
                                            <div className={cx('user__profile-posts-heading')}>
                                                <span>Bài viết nổi bật</span>
                                            </div>
                                        </div>
                                        <div className={cx('user__profile-posts-all-body')}>
                                            <div className={cx('user__profile-posts-all-content')}>
                                                <div className={cx('grid')}>
                                                    {posts.posts.slice(0, 3).map((post) => (
                                                        <PostItem post={post} key={post._id} />
                                                    ))}
                                                </div>
                                            </div>
                                        </div>
                                    </div> */}
                                    <div className={cx('user__profile-posts-top')}>
                                        <div className={cx('user__profile-posts-all-body')}>
                                            <div className={cx('user__profile-posts-all-content')}>
                                                <div className={cx('grid')}>
                                                    {posts &&
                                                        posts.map((post) => <PostItem key={post._id} post={post} />)}
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            ) : (
                                <div className={cx('empty')}>Không có gì để xem ở đây cả</div>
                            )}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default User;
