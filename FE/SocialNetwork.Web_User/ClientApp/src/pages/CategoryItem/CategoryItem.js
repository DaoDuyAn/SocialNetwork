import { useState } from 'react';
import classNames from 'classnames/bind';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleCheck } from '@fortawesome/free-solid-svg-icons';

import FilterCate from '~/components/FilterCate';
import SidebarCate from '~/components/SidebarCate';
import styles from './CategoryItem.module.scss';

const cx = classNames.bind(styles);

function CategoryItem() {
    const [isFollow, setIsFollow] = useState(false);
    const handleSubmit = () => {
    };

    const onSubmit = () => {
    };

    return (
        <main className={cx('mt-[20px]')}>
            <header className={cx('category__header')}>
                <div
                    className={cx('category__header-background')}
                    style={{ backgroundImage: `url("https://spiderum.com/assets/images/categories/laptop-min.jpg")` }}
                ></div>
                <div className={cx('category__header-container')}>
                    <div className={cx('category__header-info')}>
                        <p className={cx('category__header-title')}>KHOA HỌC - CÔNG NGHỆ</p>

                        {isFollow ? (
                            <div onClick={() => window.location.reload(false)}>
                                <button className={cx('button-page', 'active')} type="submit" onClick={handleSubmit}>
                                    <FontAwesomeIcon icon={faCircleCheck} className={cx('mr-[8px]')} />
                                    Đang theo dõi
                                </button>
                            </div>
                        ) : (
                            <div onClick={() => window.location.reload(false)}>
                                <button className={cx('button-page')} type="submit" onClick={onSubmit}>
                                    Theo dõi
                                </button>
                            </div>
                        )}
                    </div>
                </div>
            </header>
            
            <div className={cx('grid')}>
                <div className={cx('row')}>
                    <div className={cx('w-full', 'sm:w-8/12')}>
                        <FilterCate />
                    </div>
                    <div className={cx('hidden', 'sm:block', 'sm:w-4/12')}>
                        <SidebarCate />
                    </div>
                </div>
            </div>
        </main>
    );
}

export default CategoryItem;
