import classNames from 'classnames/bind';

import styles from './DatePost.module.scss';

const cx = classNames.bind(styles);

function DatePost({ date }) {
    return <span className={cx('time-read')}> - 8/8/2024</span>;
}

export default DatePost;
