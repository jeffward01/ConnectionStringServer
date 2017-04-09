// gulp
var gulp = require('gulp');

// plugins
var connect = require('gulp-connect');
var path = require('path');
var RevAll = require('gulp-rev-all');
var concat = require('gulp-concat');
var browserSync = require('browser-sync').create();
var clean = require('gulp-clean');
var inject = require('gulp-inject');
var scripts = require('./scripts');
var styles = require('./styles');
var merge = require('merge-stream');
var cleanCSS = require('gulp-clean-css');
var uglify = require('gulp-uglify');
var runSequence = require('run-sequence');
var watch = require('gulp-watch');

//development mode
var devMode = false;



//__--Tasks--__

//css compile
gulp.task('css',
    function () {
        gulp.src(styles)
            .pipe(concat('main.css'))
            .pipe(RevAll.revision())
            .pipe(gulp.dest('./dist/css'))
            .pipe(RevAll.manifestFile())
            .pipe(gulp.dest('./dist/manifest/css'))
            .pipe(browserSync.reload({
                stream: true
            }));
    });

//js compile
gulp.task('js',
    function () {

        gulp.src(scripts)
            .pipe(concat('scripts.js'))
            .pipe(RevAll.revision())
            .pipe(gulp.dest('./dist/js'))
            .pipe(RevAll.manifestFile())
            .pipe(gulp.dest('./dist/manifest/js'))
            .pipe(browserSync.reload({
                stream: true
            }));

    });

//html files
gulp.task('html',
    function () {
        gulp.src('./app/views/**/*.html')
            .pipe(gulp.dest('./dist/'))
            .pipe(browserSync.reload({
                stream: true
            }));
    });

gulp.task('purge-index',
    function () {
        gulp.src('./index.html')
            .pipe(clean())
            .pipe(RevAll.revision())
            .pipe(gulp.dest('./'));
    });

//inject sources
gulp.task('inject',
    function () {
        var jsSource = gulp.src('./dist/js/*.js', { read: false });
        var cssSource = gulp.src('./dist/css/*.css', { read: false });
        return gulp.src('./index.html')
            .pipe(inject(merge(jsSource, cssSource)))
            .pipe(clean({ force: true }))
            .pipe(gulp.dest('./'));
    });

//clean
gulp.task('clean',
    function () {
        return gulp.src('./dist', { read: false })
            .pipe(clean({ force: true }));
    });


//connect
gulp.task('connect', function () {
    connect.server({
        root: path.resolve('./'),
        port: 8888
    });
});

//minify css
gulp.task('minify-css',
    function () {
        gulp.src('./dist/css/*.css')
            .pipe(clean())
            .pipe(cleanCSS())
            .pipe(gulp.dest('./dist/css'));
    });

//minify js
gulp.task('minify-js',
    function () {
        gulp.src('./dist/js/*.js')
            .pipe(clean())
            .pipe(uglify())
            .pipe(gulp.dest('./dist/js'));
    });


//Revision Files
gulp.task('rev', function () {

    var css = gulp
        .src(styles)
        .pipe(concat('main.css'))
        .pipe(RevAll.revision())
        .pipe(gulp.dest('dist/css'));

    var js = gulp
        .src(scripts)
        .pipe(concat('scripts.js'))
        .pipe(RevAll.revision())
        .pipe(gulp.dest('dist/js'))
        .pipe(RevAll.versionFile())
        .pipe(gulp.dest('dist/buildVersion'));

    return merge(css, js);

});

gulp.task('build', ['clean'],
    function (callback) {
        runSequence('rev', 'html', 'inject', 'minify-css', callback);
    });

gulp.task('brower-sync',
    function () {
        browserSync.init(null,
            {
                open: false,
                server: {
                    baseDir: 'dist'
                }
            });
    });

gulp.task('start',
    function () {
        devMode = true;
        gulp.start(['build', 'brower-sync']);
        gulp.watch(['./app/css/**/*.css'], ['css']);
        gulp.watch(['./app/**/*.js'], ['js']);
        gulp.watch(['./app/views/**/*.html'], ['html']);
    });

gulp.task('watch',
    function () {
        gulp.watch(['./app/**/*.js', './app/views/**/*.html', styles], { ignoreIntial: false }, ['build']);
    });
function getDateTime() {
    // return new Date().toLocaleString();
    return "test";
}