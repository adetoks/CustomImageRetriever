/// <binding BeforeBuild='copy-angular-modules' />
var gulp = require('gulp'), cache = require('gulp-cached');
gulp.task('copy-angular-modules', function () {
    return gulp.src('./node_modules/angular/angular*.js')
            .pipe(cache('angular'))
            .pipe(gulp.dest('./wwwroot/lib/angular'));
});